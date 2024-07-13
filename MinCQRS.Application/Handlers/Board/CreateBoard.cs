using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.Board
{
    public sealed class CreateBoardCommand : CreateCommand<BoardModel>
    {
        public CreateBoardCommand() { }

        public CreateBoardCommand(BoardModel Board) : base(Board) { }
    }

    public sealed class CreateBoardQueryValidator : AbstractValidator<CreateBoardCommand>
    {
        public CreateBoardQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
        }
    }

    public sealed class CreateBoardHandler : BaseCommandHandler<CreateBoardHandler, CreateBoardCommand, BoardModel>
    {
        private readonly IBoardService BoardService;

        public CreateBoardHandler(
            ILogger<CreateBoardHandler> logger,
            IUnitOfWork unitOfWork,
            IBoardService BoardService
        ) : base(logger, unitOfWork)
        {
            this.BoardService = BoardService;
        }

        protected async override Task<Result<BoardModel?>> Act(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            return await BoardService.Create(request.Model, cancellationToken);
        }
    }
}
