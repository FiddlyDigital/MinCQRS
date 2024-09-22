using Microsoft.Extensions.DependencyInjection;
using Refit;
using YouTooCanKanban.API.Client.Interfaces;

namespace YouTooCanKanban.API.Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterAPIClientServices(this IServiceCollection services, string apiClientBaseURI)
        {
            services
                .AddRefitClient<IWorkspacesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
        }
    }
}
