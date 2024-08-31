using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class DeleteCardCommand : DeleteCommand<CardModel>
    {
        public DeleteCardCommand() { }

        public DeleteCardCommand(int id) : base(id) { }
    }

    public sealed class DeleteCardCommandValidator : AbstractValidator<DeleteCardCommand>
    {
        public DeleteCardCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class DeleteCardHandler : BaseCommandHandler<DeleteCardHandler, DeleteCardCommand, CardModel>
    {
        private readonly ICardService CardService;

        public DeleteCardHandler(
            ILogger<DeleteCardHandler> logger,
            IUnitOfWork unitOfWork,
            ICardService CardService
        ) : base(logger, unitOfWork)
        {
            this.CardService = CardService;
        }

        protected async override Task<Result<CardModel?>> Act(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            await CardService.Delete(request.Id, cancellationToken);
            return null;
        }
    }
}
