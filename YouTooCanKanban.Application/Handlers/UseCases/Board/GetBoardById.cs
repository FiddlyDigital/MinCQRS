using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Board
{
    public sealed class GetBoardByIdQuery : GetByIdQuery<BoardModel>
    {
        public GetBoardByIdQuery() { }

        public GetBoardByIdQuery(int id) : base(id) { }
    }

    public sealed class GetBoardByIdQueryValidator : AbstractValidator<GetBoardByIdQuery>
    {
        public GetBoardByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetBoardByIdHandler : BaseQueryHandler<GetBoardByIdHandler, GetBoardByIdQuery, BoardModel>
    {
        private readonly IBoardService BoardService;

        public GetBoardByIdHandler(
            ILogger<GetBoardByIdHandler> logger,
            IBoardService Boardervice
        ) : base(logger)
        {
            BoardService = Boardervice;
        }

        protected async override Task<Result<BoardModel?>> Act(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            return await BoardService.GetById(request.Id, cancellationToken);
        }
    }
}
