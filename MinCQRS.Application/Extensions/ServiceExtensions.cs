namespace MinCQRS.Application.Extensions
{
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using MinCQRS.DAL.Data.Interfaces;
    using MinCQRS.DAL.Data;
    using MinCQRS.Application.Handlers.SettingGroups.GetSettingGroup;
    using MinCQRS.Application.PipelineBehaviors;
    using System;
    using System.Reflection;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Services
            Assembly applicationAssembly = Assembly.GetAssembly(typeof(GetSettingGroupQuery))
                ?? throw new Exception("Can't register handlers and validators for Application");

            // Warning these are executed in the Mediatr pipeline IN THE ORDER OF REGISTRATION
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddScoped(typeof(IUnitOfWork), typeof(EFUnitOfWork<BaseDBContext>));

            return services;
        }
    }
}
