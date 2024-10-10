using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using YouTooCanKanban.API.Client.Extensions;
using YouTooCanKanban.WASMUI.Handlers;
using YouTooCanKanban.WASMUI.Services;
using YouTooCanKanban.WASMUI.Services.Data;

namespace YouTooCanKanban.WASMUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // MudBlazor UI Components
            builder.Services.AddMudServices();

            // Auth-related Services
            builder.Services.AddTransient<ITokenStorageService, TokenStorageService>();
            builder.Services.AddTransient<ApiAuthHeaderHandler>();

            // Refit Client Services DI Registration.
            string apiHostAddress = "https://localhost:44356";
            builder.Services.RegisterAPIClients(apiHostAddress);

            // Data Services
            builder.Services.AddTransient<IBoardsDataService, BoardsDataService>();
            builder.Services.AddTransient<ICardsDataService, CardsDataService>();
            builder.Services.AddTransient<ILabelsDataService, LabelsDataService>();
            builder.Services.AddTransient<IListsDataService, ListsDataService>();
            builder.Services.AddTransient<IWorkspacesDataService, WorkspacesDataService>();

            await builder.Build().RunAsync();
        }        
    }
}
