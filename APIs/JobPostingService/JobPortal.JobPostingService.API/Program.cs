using JobPortal.Core.Configuration;
using JobPortal.Core.Events;
using JobPortal.JobPostingService.Application.Extensions;
using JobPortal.JobPostingService.Infrastructure.Extensions;
using JobPortal.JobPostingService.Infrastructure.Persistence;
using JobPortal.JobPostingService.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Nest;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using FluentValidation;
using MediatR;
using JobPortal.Core.UnitOfWork;
using JobPortal.JobPostingService.Application.CQRS.Commands.JobPost;
using System.Reflection;
using JobPortal.JobPostingService.Application.Common.Mappings;
using StackExchange.Redis;
using Microsoft.Extensions.Caching.Memory;
using JobPortal.Core.Statics;

namespace JobPortal.JobPostingService.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            try
            {
                // Vault'u yapılandır ve bağlan
                await ConfigureVault(builder);

                builder.Configuration
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .Build();

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
                    var settings = new ConnectionSettings(new Uri(elasticUrl))
                        .DefaultIndex("default-index");
                    return new ElasticClient(settings);
                });

                var app = builder.Build();

                using (var scope = app.Services.CreateScope())
                {
                    var cache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
                    cache.Set(Consts.CacheKeys.HateWordsKey, new List<string>
                    {
                        "madara",
                        "nanay",
                        "parlak",
                        "pinpon",
                        "saksı",
                        "gıcık",
                        "gaga",
                        "enayi",
                        "düdük",
                        "çakmak",
                        "babaçko",
                        "armut",
                        "akmak",
                        "arakçı"
                    }, TimeSpan.FromDays(365));
                }

                // Configure the HTTP request pipeline.
                // if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                // Health checks ekle
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

                Console.WriteLine($"Vault Adresi: {vaultAddress}");

                var vaultClientSettings = new VaultClientSettings(
                    vaultAddress,
                    new TokenAuthMethodInfo(vaultToken)
                )
                {
                    Namespace = "",
                    UseVaultTokenHeaderInsteadOfAuthorizationHeader = true,
                    BeforeApiRequestAction = (httpRequestMessage, apiRequestData) =>
                    {
                        Console.WriteLine($"Vault İstek URL: {httpRequestMessage.BaseAddress.AbsoluteUri}");
                    }
                };

                var vaultClient = new VaultClient(vaultClientSettings);

                // Vault bağlantısını test et
                var healthStatus = await vaultClient.V1.System.GetHealthStatusAsync();
                Console.WriteLine($"Vault Durumu - Başlatıldı: {healthStatus.Initialized}, Mühürlü: {healthStatus.Sealed}");

                if (!healthStatus.Initialized || healthStatus.Sealed)
                {
                    throw new Exception("Vault başlatılmamış veya mühürlenmiş durumda!");
                }

                var secretKey = "JobPost";
#if DEBUG
                secretKey += "-dev";
#endif
                var secrets = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync<Dictionary<string, string>>(
                    secretKey,
                    mountPoint: "secret"
                );

                if (secrets?.Data?.Data == null)
                {
                    throw new Exception("Vault'tan sırlar okunamadı!");
                }

                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(secrets.Data.Data)
                    .Build();

                builder.Configuration.AddConfiguration(configuration);

                // Health checks ekle
                builder.Services.AddHealthChecks()
                    .AddCheck("vault", x =>
                    {
                        try
                        {
                            var health = vaultClient.V1.System.GetHealthStatusAsync().Result;
                            return health.Initialized && !health.Sealed
                                ? Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("Vault bağlantısı başarılı")
                                : Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Unhealthy("Vault başlatılmamış veya mühürlü");
                        }
                        catch (Exception ex)
                        {
                            return Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Unhealthy($"Vault bağlantı hatası: {ex.Message}");
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Vault yapılandırması sırasında hata: {ex.Message}");
                throw;
            }
        }
    }
}