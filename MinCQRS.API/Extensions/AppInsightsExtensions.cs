using Microsoft.ApplicationInsights.Extensibility;
using Serilog;

namespace MinCQRS.API.Extensions
{
    public static class AppInsightsExtensions
    {
        public static WebApplicationBuilder ConfigureAppInsights(this WebApplicationBuilder builder, string? appInsightsKey)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(appInsightsKey, nameof(appInsightsKey));

            builder.Services.AddApplicationInsightsTelemetry(opt => opt.ConnectionString = appInsightsKey);

            builder.Host.UseSerilog((ctx, services, lc) => lc
                .WriteTo.ApplicationInsights(services.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Traces)
                .ReadFrom.Configuration(ctx.Configuration)
            );

            return builder;
        }
    }
}
