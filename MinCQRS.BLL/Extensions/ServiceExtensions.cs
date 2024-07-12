using Microsoft.Extensions.DependencyInjection;
using MinCQRS.BLL.Services;

namespace MinCQRS.BLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBoardService), typeof(BoardService));
            services.AddScoped(typeof(ICardService), typeof(CardService));
            services.AddScoped(typeof(IListService), typeof(ListService));
            services.AddScoped(typeof(IWorkspaceService), typeof(WorkspaceService));
            return services;
        }
    }
}
