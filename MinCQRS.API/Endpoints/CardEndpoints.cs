using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Card;
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
}
