using JobPortal.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.EmployerService.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<DbContext, EmployerDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
} 