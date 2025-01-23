using JobPortal.Core.Repository;
using JobPortal.EmployerService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.EmployerService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployerService, Services.EmployerService>();
        services.AddScoped(typeof(GenericRepository<>), typeof(IGenericRepository<>));
        return services;
    }
}