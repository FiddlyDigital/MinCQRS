using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.API.Endpoints.Cards;
using YouTooCanKanban.Application.Handlers.UseCases.Card;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Endpoints.Cards
{
    public sealed class GetCardListEndpoint : GetListEndpoint<GetCardListQuery, CardModel>, IEndpoint
    {
        public GetCardListEndpoint() : base(Resources.Routes.Cards) { }
    }

    public sealed class GetCardByIdEndpoint : GetByIdEndpoint<GetCardByIdQuery, CardModel>, IEndpoint
    {
        public GetCardByIdEndpoint() : base(Resources.Routes.Cards) { }
    }

    public sealed class CreateCardEndpoint : CreateEndpoint<CreateCardCommand, CardModel>, IEndpoint
    {
        public CreateCardEndpoint() : base(Resources.Routes.Cards) { }
    }

    public sealed class UpdateCardEndpoint : UpdateEndpoint<UpdateCardCommand, CardModel>, IEndpoint
    {
        public UpdateCardEndpoint() : base(Resources.Routes.Cards) { }
    }

    public sealed class DeleteCardEndpoint : DeleteEndpoint<DeleteCardCommand, CardModel>, IEndpoint
    {
        public DeleteCardEndpoint() : base(Resources.Routes.Cards) { }
    }
}
