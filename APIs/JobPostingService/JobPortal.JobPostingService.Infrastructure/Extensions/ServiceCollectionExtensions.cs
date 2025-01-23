using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Infrastructure.Services;

namespace JobPortal.JobPostingService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IJobPostService, JobPostService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IWorkingMethodService, WorkingMethodService>();
            return services;
        }
    }
}