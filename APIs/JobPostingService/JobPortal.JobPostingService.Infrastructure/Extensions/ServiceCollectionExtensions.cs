using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;

namespace JobPortal.JobPostingService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(GenericRepository<>), typeof(IGenericRepository<>));
            return services;
        }
    }
}