using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Infrastructure.Services;
using JobPortal.JobPostingService.Infrastructure.Services.Elasticsearch;
using JobPortal.JobPostingService.Infrastructure.Cache.MemoryCache;
using Microsoft.Extensions.Caching.Memory;

namespace JobPortal.JobPostingService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
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

            return services;
        }
    }
}