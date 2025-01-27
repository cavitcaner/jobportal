using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Infrastructure.Services;
using JobPortal.JobPostingService.Infrastructure.Services.Elasticsearch;
using JobPortal.JobPostingService.Infrastructure.Cache.MemoryCache;
using Microsoft.Extensions.Caching.Memory;
using JobPortal.JobPostingService.Application.Interfaces.EventServices;
using MassTransit;
using JobPortal.Core.Events.EmployerEvents;

namespace JobPortal.JobPostingService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.AddMemoryCache();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ICacheService<>), typeof(MemoryCacheService<>));
            services.AddScoped<HateWordsCacheService>();
            services.AddScoped<IJobPostElasticService, JobPostElasticService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IJobPostService, JobPostService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IWorkingMethodService, WorkingMethodService>();

            services.AddScoped<IEmployerEventService, EmployerEventService>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    var rabbitMqConnectionString = configuration.GetSection("RabbitMQ:ConnectionString").Value;
                    cfg.Host(new Uri(rabbitMqConnectionString), h => { });
                });

            });

            services.AddMassTransitHostedService();


            return services;
        }
    }
}