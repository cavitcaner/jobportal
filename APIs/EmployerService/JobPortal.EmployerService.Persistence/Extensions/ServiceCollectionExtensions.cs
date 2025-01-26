using JobPortal.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.EmployerService.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<EmployerDbContext>(options =>
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }); ;
        services.AddScoped<DbContext, EmployerDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
} 