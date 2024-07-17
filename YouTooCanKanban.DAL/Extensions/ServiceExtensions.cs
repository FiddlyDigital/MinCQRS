using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Interceptors;
using YouTooCanKanban.DAL.Repos;

namespace YouTooCanKanban.DAL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, string connectionString)
        {
            ArgumentNullException.ThrowIfNull(connectionString);

            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<BaseDBContext>((sp, options) =>
                
                //options.UseSqlServer(
                options.UseSqlite(
                    connectionString,
                    t => t.MigrationsAssembly("YouTooCanKanban.DAL")
                )
                .AddInterceptors(
                    sp.GetRequiredService<SoftDeleteInterceptor>()
                )
            );

            // Data repositories
            services.AddScoped<IBoardRepo, BoardRepo>();
            services.AddScoped<ICardRepo, CardRepo>();
            services.AddScoped<IListRepo, ListRepo>();
            services.AddScoped<IWorkspaceRepo, WorkspaceRepo>();

            return services;
        }
    }
}
