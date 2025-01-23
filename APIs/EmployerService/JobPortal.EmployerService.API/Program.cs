using JobPortal.EmployerService.Infrastructure.Extensions;
using JobPortal.EmployerService.Persistence.Extensions;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using JobPortal.Core.Configuration;
using JobPortal.Core.Statics;

namespace JobPortal.EmployerService.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            await ConfigureVault(builder);

            EmployerStatics.DefaultLimitOfJobPosts = builder.Configuration.GetSection("EmployerSettings:DefaultLimitOfJobPosts").Get<short>();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static async Task ConfigureVault(WebApplicationBuilder builder)
        {
            var vaultSettings = builder.Configuration.GetSection("Vault").Get<VaultConfiguration>();
            var vaultClientSettings = new VaultClientSettings(
                vaultSettings.Address,
                new TokenAuthMethodInfo(vaultSettings.Token)
            );
            var vaultClient = new VaultClient(vaultClientSettings);

            var secrets = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync<Dictionary<string, string>>(
                "JobPost",
                mountPoint: "secret"
            );

            if (secrets?.Data?.Data != null)
            {
                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(secrets.Data.Data)
                    .Build();
                builder.Configuration.AddConfiguration(configuration);
            }
        }
    }
}