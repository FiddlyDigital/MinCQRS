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
    public sealed class DeleteBoardCommand : DeleteCommand<BoardModel>
    {
        public DeleteBoardCommand() { }

        public DeleteBoardCommand(int id) : base(id) { }
    }

    public sealed class DeleteBoardQueryValidator : AbstractValidator<DeleteBoardCommand>
    {
        public DeleteBoardQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class DeleteBoardHandler : BaseCommandHandler<DeleteBoardHandler, DeleteBoardCommand, BoardModel>
    {
        private readonly IBoardService BoardService;

        public DeleteBoardHandler(
            ILogger<DeleteBoardHandler> logger,
            IUnitOfWork unitOfWork,
            IBoardService BoardService
        ) : base(logger, unitOfWork)
        {
            this.BoardService = BoardService;
        }

        protected async override Task<Result<BoardModel?>> Act(DeleteBoardCommand request, CancellationToken cancellationToken)
        {
            await BoardService.Delete(request.Id, cancellationToken);
            return null;
        }
    }
}
