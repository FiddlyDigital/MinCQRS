using System.IO.Compression;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.BLL.Mapping;
using YouTooCanKanban.Domain.Extensions;

namespace YouTooCanKanban.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            ServiceDescriptor[] apiEndpoints = assembly
                .DefinedTypes
                .Where(type => 
                    type is { 
                        IsSealed: true,
                        IsAbstract: false, 
                        IsInterface: false             } 
                    && type.IsAssignableTo(typeof(IEndpoint)))
                .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
                .ToArray();

            services.TryAddEnumerable(apiEndpoints);
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

        public static void ConfigureResponseCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });
        }
            
    }
}
