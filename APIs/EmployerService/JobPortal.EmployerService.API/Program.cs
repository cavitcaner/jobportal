using JobPortal.EmployerService.Infrastructure.Extensions;
using JobPortal.EmployerService.Persistence.Extensions;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using JobPortal.Core.Configuration;
using JobPortal.Core.Statics;
using JobPortal.Core.UnitOfWork;
using JobPortal.EmployerService.Application.Extensions;
using Nest;
using System.Reflection;

namespace JobPortal.EmployerService.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            try
            {
                await ConfigureVault(builder);

                EmployerStatics.DefaultLimitOfJobPosts = builder.Configuration.GetSection("EmployerSettings:DefaultLimitOfJobPosts").Get<short>();

                // Add services to the container.

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                });
                builder.Services.AddPersistenceServices(builder.Configuration);
                builder.Services.AddApplicationServices();
                builder.Services.AddInfrastructureServices();
                builder.Services.AddSingleton<IElasticClient>(sp =>
                {
                    var elasticUrl = builder.Configuration.GetValue<string>("Elasticsearch:Url");
                    var settings = new ConnectionSettings(new Uri(elasticUrl)).DefaultIndex("default-index");
                    return new ElasticClient(settings);
                });

                var app = builder.Build();

               // if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.MapHealthChecks("/health");

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uygulama başlatılırken hata oluştu: {ex.Message}");
                throw;
            }
        }
        private static async Task ConfigureVault(WebApplicationBuilder builder)
        {
            try
            {
                var vaultAddress = Environment.GetEnvironmentVariable("VAULT_ADDR") ?? "http://localhost:8200";
                var vaultToken = Environment.GetEnvironmentVariable("VAULT_TOKEN") ?? "admin";

                Console.WriteLine($"vaultAddress:{vaultAddress}");
                Console.WriteLine($"vaultToken:{vaultToken}");

                var vaultClientSettings = new VaultClientSettings(
                    vaultAddress,
                    new TokenAuthMethodInfo(vaultToken)
                )
                {
                    Namespace = "",
                    UseVaultTokenHeaderInsteadOfAuthorizationHeader = true,
                    BeforeApiRequestAction = (httpRequestMessage, apiRequestData) =>
                    {
                        Console.WriteLine($"Vault Request URL: {httpRequestMessage.BaseAddress.AbsoluteUri}");
                        Console.WriteLine($"Vault Request Headers: {string.Join(", ", httpRequestMessage.DefaultRequestHeaders)}");
                    }
                };

                var vaultClient = new VaultClient(vaultClientSettings);

                // Vault bağlantısını test et
                var healthStatus = await vaultClient.V1.System.GetHealthStatusAsync();
                Console.WriteLine($"Vault Status - Initialized: {healthStatus.Initialized}, Sealed: {healthStatus.Sealed}, Standby: {healthStatus.Standby}");

                // Sealed durumu false ise devam et
                if (!healthStatus.Initialized)
                {
                    throw new Exception("Vault is not initialized!");
                }

                var secrets = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync<Dictionary<string, string>>(
                    "JobPost",
                    mountPoint: "secret"
                );

                if (secrets?.Data?.Data == null)
                {
                    throw new Exception("Failed to read secrets from Vault!");
                }

                foreach (var secret in secrets.Data.Data)
                {
                    Console.WriteLine($"Secret Key: {secret.Key}");
                }

                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(secrets.Data.Data)
                    .Build();

                builder.Configuration.AddConfiguration(configuration);

                // Health checks
                builder.Services.AddHealthChecks()
                    .AddCheck("vault", () =>
                    {
                        try
                        {
                            var health = vaultClient.V1.System.GetHealthStatusAsync().Result;
                            return health.Initialized
                                ? Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("Vault connection successful")
                                : Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Unhealthy("Vault is not initialized");
                        }
                        catch (Exception ex)
                        {
                            return Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Unhealthy($"Vault connection error: {ex.Message}");
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Vault configuration error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}