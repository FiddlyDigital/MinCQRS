using YouTooCanKanban;
using YouTooCanKanban.API;
using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.API.Endpoints.Boards;
using YouTooCanKanban.Application.Handlers.UseCases.Board;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Endpoints.Boards
{
    public sealed class GetBoardListEndpoint : GetListEndpoint<GetBoardListQuery, BoardModel>, IEndpoint
    {
        public GetBoardListEndpoint() : base(Resources.Routes.Boards) { }
    }

    public sealed class GetBoardByIdEndpoint : GetByIdEndpoint<GetBoardByIdQuery, BoardModel>, IEndpoint
    {
        public GetBoardByIdEndpoint() : base(Resources.Routes.Boards) { }
    }

    public sealed class CreateBoardEndpoint : CreateEndpoint<CreateBoardCommand, BoardModel>, IEndpoint
    {
        public CreateBoardEndpoint() : base(Resources.Routes.Boards) { }
    }

    public sealed class UpdateBoardEndpoint : UpdateEndpoint<UpdateBoardCommand, BoardModel>, IEndpoint
    {
        public UpdateBoardEndpoint() : base(Resources.Routes.Boards) { }
    }

    public sealed class DeleteBoardEndpoint : DeleteEndpoint<DeleteBoardCommand, BoardModel>, IEndpoint
    {
        public DeleteBoardEndpoint() : base(Resources.Routes.Boards) { }
    }
}
