using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Board
{
    public sealed class GetBoardListQuery : GetListQuery<BoardModel>
    {
        public GetBoardListQuery() : base() { }

        public GetBoardListQuery(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter) : base(pageIndex, pageSize, sortBy, sortDir, filter) { }
    }

    public sealed class GetBoardListQueryValidator : AbstractValidator<GetBoardListQuery>
    {
        public GetBoardListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1).LessThan(100);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetBoardListHandler : BaseQueryHandler<GetBoardListHandler, GetBoardListQuery, IEnumerable<BoardModel>>
    {
        private readonly IBoardService BoardService;

        public GetBoardListHandler(
            ILogger<GetBoardListHandler> logger,
            IBoardService BoardService
        ) : base(logger)
        {
            this.BoardService = BoardService;
        }

        protected async override Task<Result<IEnumerable<BoardModel>>> Act(GetBoardListQuery request, CancellationToken cancellationToken)
        {
            return await BoardService.GetList(request.PageIndex, request.PageSize, request.SortBy, request.SortDir, request.Filter);
        }
    }
}
