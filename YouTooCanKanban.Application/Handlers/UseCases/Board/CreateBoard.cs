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
            RuleFor(x => x.Model.Id).LessThanOrEqualTo(0).GreaterThanOrEqualTo(-1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.WorkspaceId).GreaterThanOrEqualTo(1);
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
