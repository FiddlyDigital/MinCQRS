using Microsoft.Extensions.DependencyInjection;
using MinCQRS.BLL.Services;

namespace MinCQRS.BLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IWorkspaceService), typeof(WorkspaceService));
            services.AddScoped(typeof(IBoardService), typeof(BoardService));
            return services;
        }
    }
}
