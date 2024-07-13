using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.List;
using MinCQRS.Application.Handlers.List;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    public sealed class GetListListEndpoint : GetListEndpoint<GetListListQuery, ListModel>, IEndpoint
    {
        public GetListListEndpoint() : base(Resources.Routes.Lists) { }
    }

    public sealed class GetListByIdEndpoint : GetByIdEndpoint<GetListByIdQuery, ListModel>, IEndpoint
    {
        public GetListByIdEndpoint() : base(Resources.Routes.Lists) { }
    }

    public sealed class CreateListEndpoint : CreateEndpoint<CreateListCommand, ListModel>, IEndpoint
    {
        public CreateListEndpoint() : base(Resources.Routes.Lists) { }
    }
}
