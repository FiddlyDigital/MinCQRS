using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;

namespace YouTooCanKanban.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
            // IEndpoint are made availabe here by ServiceExtensions.AddEndpoints
            IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

            IEndpointRouteBuilder builder = (routeGroupBuilder is null)
                ? app 
                : routeGroupBuilder;

            foreach (IEndpoint endpoint in endpoints)
            {
                endpoint.MapEndpoint(builder);
            }

            return app;
        }
    }
}
