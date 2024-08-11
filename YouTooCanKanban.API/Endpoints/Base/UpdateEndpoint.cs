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
    public abstract class UpdateEndpoint<TCommand, TModel>
        where TCommand : UpdateCommand<TModel>, new()
        where TModel : BaseModel
    {
        private readonly string EndpointRoute;

        public UpdateEndpoint(string endpoint)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));
            EndpointRoute = endpoint;
        }

        private static async Task<IResult> UpdateAsync(ISender mediator, int id, TModel model)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            if (id <= 0 || model.Id <= 0 || id != model.Id)
            {
                throw new ArgumentException("Id mismatch", nameof(id));
            }

            var updateCommand = new TCommand();
            updateCommand.Model = model;

            var result = await mediator.Send(updateCommand);

            // We ignore the result value here, and just return no-content to signify success
            return result.Match(
                Succ: _ => Results.NoContent(),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut(EndpointRoute + "/{id}", (
                    ISender mediator,
                    [FromRoute(Name = "id")] int id,
                    [FromBody()] TModel model
                ) => UpdateAsync(mediator, id, model))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Updates an existing " + EndpointRoute,
                    Description = "Will Update an existing " + EndpointRoute + ".",
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
