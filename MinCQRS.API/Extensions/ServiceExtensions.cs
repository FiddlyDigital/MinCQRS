namespace MinCQRS.API.Extensions
{
    using System.Reflection;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using MinCQRS.API.Endpoints;
    using MinCQRS.BLL.Mapping;
    using MinCQRS.Domain.Extensions;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            ServiceDescriptor[] serviceDescriptors = assembly
                .DefinedTypes
                .Where(type => 
                    type is { 
                        IsAbstract: false, 
                        IsInterface: false 
                    } 
                    && type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);
            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static void ConfigureMappingUtil(this IApplicationBuilder applicationBuilder)
        {
            IMapper? mapper = applicationBuilder.ApplicationServices.GetService<IMapper>();

            if (mapper is null)
            {
                throw new Exception("Unable to inject IMapper");
            }

            MappingExtensions.InitializeMapper(mapper);
        }
    }
}
