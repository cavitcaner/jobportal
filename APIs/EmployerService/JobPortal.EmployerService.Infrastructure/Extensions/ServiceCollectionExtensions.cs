using JobPortal.Core.Repository;
using JobPortal.Core.UnitOfWork;
using JobPortal.EmployerService.Application.Services;
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