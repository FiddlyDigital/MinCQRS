using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.UseCases.Board
{
    public sealed class UpdateBoardCommand : UpdateCommand<BoardModel>
    {
        public UpdateBoardCommand() { }

        public UpdateBoardCommand(BoardModel Board) : base(Board) { }
    }

    public sealed class UpdateBoardQueryValidator : AbstractValidator<UpdateBoardCommand>
    {
        public UpdateBoardQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
        }
    }

    public sealed class UpdateBoardHandler : BaseCommandHandler<UpdateBoardHandler, UpdateBoardCommand, BoardModel>
    {
        private readonly IBoardService BoardService;

        public UpdateBoardHandler(
            ILogger<UpdateBoardHandler> logger,
            IUnitOfWork unitOfWork,
            IBoardService BoardService
        ) : base(logger, unitOfWork)
        {
            this.BoardService = BoardService;
        }

        protected async override Task<Result<BoardModel?>> Act(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            await BoardService.Update(request.Model, cancellationToken);
            return null;
        }
    }
}
