using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.Application.PipelineBehaviors;
using System;
using System.Reflection;
using YouTooCanKanban.Application.Handlers.UseCases.Workspace;


namespace YouTooCanKanban.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Warning these are executed in the Mediatr pipeline IN THE ORDER OF REGISTRATION
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            // Services
            Assembly applicationAssembly = Assembly.GetAssembly(typeof(GetWorkspaceByIdQuery))
                ?? throw new Exception("Can't register handlers and validators for Application");

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(applicationAssembly);
                //cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(applicationAssembly, includeInternalTypes: true);
            services.AddScoped(typeof(IUnitOfWork), typeof(EFUnitOfWork<BaseDBContext>));

            return services;
        }
    }
}
