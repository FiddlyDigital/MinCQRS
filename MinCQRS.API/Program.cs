using Asp.Versioning;
using Asp.Versioning.Builder;
using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MinCQRS.API.Extensions;
using MinCQRS.Application.Extensions;
using MinCQRS.BLL.Extensions;
using MinCQRS.DAL.Extensions;
using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace MinCQRS.API
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WebApplicationBuilder builder = CreateAndConfigBuilder(args);
            WebApplication app = CreateAndConfigWebApp(builder);
            app.Run();
        }

        private static WebApplicationBuilder CreateAndConfigBuilder(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            var appInsightsKey = builder.Configuration.GetValue<string>("ApplicationInsights:InstrumentationKey");
            var dbConn = builder.Configuration.GetConnectionString("DBConn");
            if (string.IsNullOrEmpty(dbConn))
            {
                Console.WriteLine("Database connection string is not defined. Aborting startup");
                System.Environment.Exit(0);
            }

            // Application Insights
            builder.ConfigureAppInsights(appInsightsKey);

            // DI for each Layer
            RegisterDependencies(builder, dbConn);

            builder.Services
                .AddProblemDetails(ConfigureProblemDetails)
                .AddProblemDetailsConventions();

            // API Config
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureAutoMapper();
            builder.Services.AddLogging();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAllHeadersPolicy",
                    policy =>
                    {
                        policy
                            .WithOrigins(
                                "https://localhost",
                                "http://localhost",
                                "https://127.0.0.1",
                                "http://127.0.0.1"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return builder;
        }

        private static void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            options.OnBeforeWriteDetails = (context, details) =>
            {
                if (details.Status == 500)
                {
                    details.Detail = "An error occurred in our API. Use the trace id when contacting us.";
                }
            };

            // You can configure the middleware to re-throw certain types of exceptions, all exceptions or based on a predicate.
            // This is useful if you have upstream middleware that needs to do additional handling of exceptions.
            options.Rethrow<NotSupportedException>();

            options.MapToStatusCode<TaskCanceledException>(StatusCodes.Status499ClientClosedRequest);
            options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
            options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);

            // Because exceptions are handled polymorphically, this will act as a "catch all" mapping, which is why it's added last.
            // If an exception other than TaskCanceledException, NotImplementedException and HttpRequestException is thrown, this will handle it.
            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
        }

        private static void RegisterDependencies(WebApplicationBuilder builder, string? dbConn)
        {
            builder.Services.AddDALServices(dbConn);
            builder.Services.AddBLLServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddAPIServices();
        }

        private static WebApplication CreateAndConfigWebApp(WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1);
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                }).AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });

            builder.Services.AddEndpoints(typeof(Program).Assembly);
            builder.Services.AddResponseCompression();

            WebApplication app = builder.Build();

            ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1))
                .ReportApiVersions()
                .Build();

            RouteGroupBuilder versionedGroup = app
                .MapGroup("api/v{version:apiVersion}")
                .WithApiVersionSet(apiVersionSet);

            app.ConfigureMappingUtil();
            app.MapEndpoints(versionedGroup);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            return app;
        }
    }
}