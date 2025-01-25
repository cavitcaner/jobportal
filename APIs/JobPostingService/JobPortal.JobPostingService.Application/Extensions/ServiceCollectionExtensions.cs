using Microsoft.Extensions.DependencyInjection;
using JobPortal.Core.Repository;
using FluentValidation;
using System.Reflection;
using JobPortal.JobPostingService.Application.Behaviors;
using JobPortal.JobPostingService.Application.CQRS.Commands.JobPost;
using MediatR;
using JobPortal.JobPostingService.Application.Common.Mappings;

namespace JobPortal.JobPostingService.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(JobPostMappingProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}