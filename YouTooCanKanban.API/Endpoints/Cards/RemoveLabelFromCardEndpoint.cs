using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.OpenApi.Models;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.UseCases.Card;

namespace YouTooCanKanban.API.Endpoints.Cards
{
    public sealed class RemoveLabelFromCardEndpoint : IEndpoint
    {
        private async Task<IResult> RemoveLabelFromCardAsync(ISender mediator, int cardId = -1, int labelId = -1)
        {
            if (cardId < 1)
            {
                return Results.BadRequest("CardId needs to be a valid value.");
            }

            if (labelId < 1)
            {
                return Results.BadRequest("LabelId needs to be a valid value.");
            }

            var RemoveLabelFromCardCommand = new RemoveLabelFromCardCommand();
            RemoveLabelFromCardCommand.LabelId = labelId;
            RemoveLabelFromCardCommand.CardId = cardId;

            var result = await mediator.Send(RemoveLabelFromCardCommand);

            return result.Match(
                Succ: val => Results.Ok(val),
                Fail: exception => Results.Problem(exception.Message));
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete(
                Resources.Routes.Cards + "/{cardId}/" + Resources.Routes.Labels + "/{labelId}", (
                    ISender mediator,
                    [FromRoute(Name = "cardId")] int cardId,
                    [FromRoute(Name = "labelId")] int labelId
                ) => RemoveLabelFromCardAsync(mediator, cardId, labelId))
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Removes a label from a Card",
                    Description = "Will remove a label from a Card.",
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
