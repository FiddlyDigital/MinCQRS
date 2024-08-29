using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.UseCases.Card;

namespace YouTooCanKanban.API.Endpoints.Cards
{
    public sealed class AddLabelToCardEndpoint : IEndpoint
    {
        public AddLabelToCardEndpoint()
        {
        }

        private async Task<IResult> AddLabelToCardAsync(ISender mediator, int cardId = -1, int labelId = -1)
        {
            if (cardId < 1)
            {
                return Results.BadRequest("CardId needs to be a valid value.");
            }

            if (labelId < 1)
            {
                return Results.BadRequest("LabelId needs to be a valid value.");
            }

            var addLabelToCardCommand = new AddLabelToCardCommand();
            addLabelToCardCommand.LabelId = labelId;
            addLabelToCardCommand.CardId = cardId;

            var result = await mediator.Send(addLabelToCardCommand);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost(
                Resources.Routes.Cards + "/{cardId}/" + Resources.Routes.Labels + "/{labelId}", (
                    ISender mediator,
                    [FromRoute(Name = "cardId")] int cardId,
                    [FromRoute(Name = "labelId")] int labelId
                ) => AddLabelToCardAsync(mediator, cardId, labelId))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Adds a label to a Card",
                    Description = "Will add a label to a Card.",
                    Tags = new[]
                    {
                        new OpenApiTag()
                        {
                            Name = Resources.Routes.Cards,
                        }
                    }
                });
        }
    }
}
