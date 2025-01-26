using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using JobPortal.Core;
using JobPortal.Core.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace JobPortal.JobPostingService.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<JobPostingDbContext>(options =>
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }); ;
            services.AddScoped<DbContext, JobPostingDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}