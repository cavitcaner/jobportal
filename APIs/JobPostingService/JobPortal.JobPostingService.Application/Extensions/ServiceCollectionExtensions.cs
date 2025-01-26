using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using JobPortal.Core.Behaviors;
using MediatR;
using JobPortal.JobPostingService.Application.Common.Mappings;

namespace JobPortal.JobPostingService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}