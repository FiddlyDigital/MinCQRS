namespace MinCQRS.API.Extensions
{
    using MinCQRS.API.Endpoints;
    using MinCQRS.API.Endpoints.SettingGroups;

    public static class WebApplicationExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
        {
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
