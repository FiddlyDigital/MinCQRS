using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Board
{
    public sealed class UpdateBoardCommand : UpdateCommand<BoardModel>
    {
        public UpdateBoardCommand() { }

        public UpdateBoardCommand(BoardModel Board) : base(Board) { }
    }

    public sealed class UpdateBoardCommandValidator : AbstractValidator<UpdateBoardCommand>
    {
        public UpdateBoardCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.WorkspaceId).GreaterThanOrEqualTo(1);
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
