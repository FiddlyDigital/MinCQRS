using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using YouTooCanKanban.API.Client.Extensions;

namespace YouTooCanKanban.WASMUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // MudBlazor UI
            builder.Services.AddMudServices();

            // Refit Client Services DI Registration.
            string apiHostAddress = "http://localhost:5208";
            builder.Services.RegisterAPIClientServices(apiHostAddress);

            await builder.Build().RunAsync();
        }
    }
}
