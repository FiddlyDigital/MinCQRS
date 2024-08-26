using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.API.Endpoints.Lists;
using YouTooCanKanban.Application.Handlers.UseCases.List;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Endpoints.Lists
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
