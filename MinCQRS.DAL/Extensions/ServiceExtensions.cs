namespace MinCQRS.DAL.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MinCQRS.DAL.Data;
    using MinCQRS.DAL.Interceptors;
    using MinCQRS.DAL.Repos;
    using MinCQRS.DAL.Repos.Interfaces;
    using System;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, string connectionString)
        {
            ArgumentNullException.ThrowIfNull(connectionString);

            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<BaseDBContext>((sp, options) => 
                options.UseSqlServer(
                    connectionString,
                    t => t.MigrationsAssembly("MinCQRS.DAL")
                )
                .AddInterceptors(
                    sp.GetRequiredService<SoftDeleteInterceptor>()
                )
            );

            // Data repositories
            services.AddScoped<ISettingGroupsRepo, SettingGroupsRepo>();
            services.AddScoped<IMicrositeRepo, MicrositeRepo>();
            services.AddScoped<IPageTemplateRepo, PageTemplateRepo>();
            services.AddScoped<IPageRepo, PageRepo>();
            services.AddScoped<IBlockTemplateRepo, BlockTemplateRepo>();
            services.AddScoped<IBlockRepo, BlockRepo>();
            services.AddScoped<IElementTemplateRepo, ElementTemplateRepo>();
            services.AddScoped<IElementRepo, ElementRepo>();

            return services;
        }
    }
}
