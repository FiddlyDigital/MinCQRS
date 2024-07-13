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
    public abstract class GetByIdEndpoint<TQuery, TModel>
        where TQuery : GetByIdQuery<TModel>, new()
        where TModel : BaseModel
    {
        private readonly string EndpointRoute;

        public GetByIdEndpoint(string endpoint)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private static async Task<IResult> GetByIdAsync(ISender mediator, int id)
        {
            var getByIdQuery = new TQuery();
            getByIdQuery.Id = id;

            var result = await mediator.Send(getByIdQuery);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet(EndpointRoute + "/{id}", (
                    ISender mediator,
                    [FromRoute(Name = "id")] int id
                ) => GetByIdAsync(mediator, id))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Requests a specific " + EndpointRoute,
                    Description = "Will return a specific " + EndpointRoute + " if it exists, otherwise 404",
                    Tags = new[]
                    {
                        new OpenApiTag()
                        {
                            Name = EndpointRoute,
                        }
                    }
                });
        }
    }
}
