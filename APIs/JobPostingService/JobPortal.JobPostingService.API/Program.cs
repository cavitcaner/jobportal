
using JobPortal.Core.Configuration;
using JobPortal.Core.Events;
using JobPortal.JobPostingService.Application.Extensions;
using JobPortal.JobPostingService.Infrastructure.Extensions;
using JobPortal.JobPostingService.Infrastructure.Persistence;
using JobPortal.JobPostingService.Persistence.EventHandlers;
using JobPortal.JobPostingService.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace JobPortal.JobPostingService.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            await ConfigureVault(builder);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(
                    typeof(Program).Assembly,
                    typeof(IEvent).Assembly
                );
            }); 
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddPersistenceServices();
            builder.Services.AddDbContext<JobPostingDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    npgsqlOptionsAction: opts =>
                    {
                        opts.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorCodesToAdd: null);
                    });
            });

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