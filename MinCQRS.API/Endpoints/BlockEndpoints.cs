using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Board;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
{
    public sealed class GetBoardListEndpoint : GetListEndpoint<GetBoardListQuery, BoardModel>, IEndpoint
    {
        public GetBoardListEndpoint() : base(Resources.Routes.Boards) { }
    }

    public sealed class GetBoardByIdEndpoint : GetByIdEndpoint<GetBoardByIdQuery, BoardModel>, IEndpoint
    {
        public GetBoardByIdEndpoint() : base(Resources.Routes.Boards) { }
    }
}
