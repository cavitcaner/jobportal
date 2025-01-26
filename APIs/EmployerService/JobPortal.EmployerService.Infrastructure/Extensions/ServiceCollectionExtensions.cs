using JobPortal.Core.Repository;
using JobPortal.EmployerService.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.EmployerService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IEmployerService, Services.EmployerService>();
        return services;
    }
}