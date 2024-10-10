using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.WASMUI.Handlers;

namespace YouTooCanKanban.API.Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterAPIClients(this IServiceCollection services, string apiClientBaseURI)
        {
            services
                .AddRefitClient<IBoardsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
                //.AddHttpMessageHandler<ApiAuthHeaderHandler>()
                //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services
                .AddRefitClient<ICardsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
                //.AddHttpMessageHandler<ApiAuthHeaderHandler>()
                //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services
                .AddRefitClient<ILabelsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
                //.AddHttpMessageHandler<ApiAuthHeaderHandler>()
                //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services
                .AddRefitClient<IListsClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
                //.AddHttpMessageHandler<ApiAuthHeaderHandler>()
                //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services
                .AddRefitClient<IWorkspacesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiClientBaseURI));
                //.AddHttpMessageHandler<ApiAuthHeaderHandler>()
                //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        }
    }
}
