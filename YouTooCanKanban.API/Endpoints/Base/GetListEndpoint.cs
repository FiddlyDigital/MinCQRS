using System.Drawing.Printing;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.API.Endpoints.Base
{
    public abstract class GetListEndpoint<TQuery, TResponse>
        where TQuery : GetListQuery<TResponse>, new()
        where TResponse : BaseModel
    {
        private readonly string EndpointRoute;

        public GetListEndpoint(string endpoint)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private async Task<IResult> GetListAsync(
            ISender mediator,
            int page = 1,
            int pageSize = 25,
            string? sortBy = null,
            string? sortDir = null,
            string? filter = null
        )
        {
            if (page < 1)
            {
                return Results.BadRequest("A");
            }

            if (pageSize < 1)
            {
                return Results.BadRequest("B");
            }

            TQuery getListQuery = new TQuery()
            {
                PageSize = pageSize,
                PageIndex = page - 1,
                SortBy = sortBy,
                SortDir = sortDir,
                Filter = filter
            };

            var result = await mediator.Send(getListQuery);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointRoute, (
                    ISender mediator,
                    [FromQuery(Name = "page")] int page,
                    [FromQuery(Name = "pageSize")] int pageSize,
                    [FromQuery(Name = "sortBy")] string? sortBy,
                    [FromQuery(Name = "sortDir")] string? sortDir,
                    [FromQuery(Name = "filter")] string? filter
                ) =>
                GetListAsync(mediator, page, pageSize, sortBy, sortDir, filter))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Requests a list of " + EndpointRoute,
                    Description = "Will return a paginated list of " + EndpointRoute,
                    Tags = new[]
                    {
                        new OpenApiTag()
                        {
                            Name = EndpointRoute,
                        }
                    }
                })
            .Produces<ICollection<TResponse>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
