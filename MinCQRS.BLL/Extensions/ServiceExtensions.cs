using Microsoft.Extensions.DependencyInjection;
using MinCQRS.BLL.Services;

namespace MinCQRS.BLL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISettingGroupService), typeof(SettingGroupService));
            services.AddScoped(typeof(IMicrositeService), typeof(MicrositeService));
            services.AddScoped(typeof(IPageTemplateService), typeof(PageTemplateService));
            services.AddScoped(typeof(IPageService), typeof(PageService));
            services.AddScoped(typeof(IBlockTemplateService), typeof(BlockTemplateService));
            services.AddScoped(typeof(IBlockService), typeof(BlockService));
            services.AddScoped(typeof(IElementTemplateService), typeof(ElementTemplateService));
            services.AddScoped(typeof(IElementService), typeof(ElementService));
            return services;
        }
    }
}
