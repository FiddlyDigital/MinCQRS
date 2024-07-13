using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.UseCases.List;
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

    public sealed class UpdateListEndpoint : UpdateEndpoint<UpdateListCommand, ListModel>, IEndpoint
    {
        public UpdateListEndpoint() : base(Resources.Routes.Lists) { }
    }

    public sealed class DeleteListEndpoint : DeleteEndpoint<DeleteListCommand, ListModel>, IEndpoint
    {
        public DeleteListEndpoint() : base(Resources.Routes.Lists) { }
    }
}
