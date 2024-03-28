namespace MinCQRS.BLL.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using MinCQRS.BLL.Services;
    using MinCQRS.BLL.Services.Interfaces;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISettingGroupService), typeof(SettingGroupService));
            return services;
        }
    }
}
