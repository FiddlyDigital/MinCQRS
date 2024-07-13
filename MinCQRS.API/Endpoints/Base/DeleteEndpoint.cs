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
    public abstract class DeleteEndpoint<TCommand, TModel>
        where TCommand : DeleteCommand<TModel>, new()
        where TModel : BaseModel
    {
        private readonly string EndpointRoute;

        public DeleteEndpoint(string endpoint)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private static async Task<IResult> DeleteAsync(ISender mediator, int id)
        {
            var deleteCommand = new TCommand();
            deleteCommand.Id = id;

            var result = await mediator.Send(deleteCommand);

            // We ignore the result value here, and just return no-content to signify successful deletion
            return result.Match(
                Succ: _ => Results.NoContent(),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete(EndpointRoute + "/{id}", (
                    ISender mediator,
                    [FromRoute(Name = "id")] int id
                ) => DeleteAsync(mediator, id))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Deletes an existing " + EndpointRoute,
                    Description = "Will Delete an existing " + EndpointRoute + ".",
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
