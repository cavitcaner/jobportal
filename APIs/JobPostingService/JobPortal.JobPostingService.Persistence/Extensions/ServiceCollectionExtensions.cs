using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using JobPortal.Core;

namespace JobPortal.JobPostingService.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<BaseDbContext, JobPostingDbContext>();
            services.AddScoped<DbContext, JobPostingDbContext>();
            return services;
        }
    }
}