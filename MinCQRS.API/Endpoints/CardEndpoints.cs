using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.UseCases.Card;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
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
