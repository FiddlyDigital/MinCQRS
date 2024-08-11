using Microsoft.Extensions.DependencyInjection;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Data;

namespace YouTooCanKanban.BLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(EFUnitOfWork<BaseDBContext>));

            services.AddScoped(typeof(IBoardService), typeof(BoardService));
            services.AddScoped(typeof(ICardService), typeof(CardService));
            services.AddScoped(typeof(ILabelService), typeof(LabelService));
            services.AddScoped(typeof(IListService), typeof(ListService));
            services.AddScoped(typeof(IWorkspaceService), typeof(WorkspaceService));
            return services;
        }
    }
}
