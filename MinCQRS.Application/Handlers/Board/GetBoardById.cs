using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Board
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
            this.BoardService = Boardervice;
        }

        protected async override Task<Result<BoardModel?>> Act(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            return await BoardService.GetById(request.Id, cancellationToken);
        }
    }
}
