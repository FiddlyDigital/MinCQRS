using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MinCQRS;
using MinCQRS.API;
using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Domain.Models;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.API.Endpoints.Base
{
    public abstract class GetListEndpoint<TQuery, TModel>
        where TQuery : GetListQuery<TModel>, new()
        where TModel : BaseModel
    {
        private readonly string EndpointRoute;

        public GetListEndpoint(string endpoint)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private async Task<IResult> GetListAsync(ISender mediator, int page = 1, int pageSize = 25)
        {
            if (page < 1)
            {
                return Results.BadRequest("A");
            }

            if (pageSize < 1)
            { 
                return Results.BadRequest("B");
            }

            var getListQuery = new TQuery()
            {
                PageSize = pageSize,
                PageIndex = page - 1
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
                    [FromQuery(Name = "pageSize")] int pageSize
                ) => GetListAsync(mediator, page, pageSize))
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
            .Produces<ICollection<TModel>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
