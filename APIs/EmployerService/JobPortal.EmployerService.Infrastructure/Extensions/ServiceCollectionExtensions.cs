using JobPortal.Core.Repository;
using JobPortal.EmployerService.Application.Interfaces;
using JobPortal.EmployerService.Infrastructure.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.EmployerService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IEmployerService, Services.EmployerService>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitMqConnectionString = configuration.GetSection("RabbitMQ:ConnectionString").Value;
                cfg.Host(new Uri(rabbitMqConnectionString), h => { });


                cfg.ReceiveEndpoint("GetEmployerJobPostingLimitEventRequest", x =>
                {
                    x.ConfigureConsumer<GetEmployerJobPostingLimitConsumer>(context);
                });
                cfg.ReceiveEndpoint("JobPostCreatedEventRequest", x =>
                {
                    x.ConfigureConsumer<JobPostCreatedEventConsumer>(context);
                });
            });

            x.AddConsumer<GetEmployerJobPostingLimitConsumer>();
            x.AddConsumer<JobPostCreatedEventConsumer>();

        });

        services.AddMassTransitHostedService();

        return services;
    }
}