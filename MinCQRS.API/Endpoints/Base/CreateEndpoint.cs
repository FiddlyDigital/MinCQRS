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
    public abstract class CreateEndpoint<TCommand, TModel>
        where TCommand : CreateCommand<TModel>, new()
        where TModel : BaseModel
    {
        private readonly string EndpointRoute;

        public CreateEndpoint(string endpoint)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private static async Task<IResult> CreateAsync(ISender mediator, TModel model)
        {
            var createQuery = new TCommand();
            createQuery.Model = model;

            var result = await mediator.Send(createQuery);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(EndpointRoute + "/{id}", (
                    ISender mediator,
                    [FromBody()] TModel model
                ) => CreateAsync(mediator, model))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Creates a new" + EndpointRoute,
                    Description = "Will create a new " + EndpointRoute + ".",
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
