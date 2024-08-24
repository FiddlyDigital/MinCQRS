using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class RemoveLabelFromCardCommand : ICommand<Result<bool>>
    {
        public int LabelId { get; set; }
        public int CardId { get; set; }

        public RemoveLabelFromCardCommand() { }

        public RemoveLabelFromCardCommand(int labelId, int cardId)
        {
            this.LabelId = labelId;
            this.CardId = cardId;
        }
    }

    public sealed class RemoveLabelFromCardCommandValidator : AbstractValidator<RemoveLabelFromCardCommand>
    {
        public RemoveLabelFromCardCommandValidator()
        {
            RuleFor(x => x.LabelId).GreaterThan(0);
            RuleFor(x => x.CardId).GreaterThan(0);
        }

        public sealed class RemoveLabelFromCardHandler : BaseCommandHandler<RemoveLabelFromCardHandler, RemoveLabelFromCardCommand, bool>
        {
            private readonly ICardService CardService;

            public RemoveLabelFromCardHandler(
                ILogger<RemoveLabelFromCardHandler> logger,
                IUnitOfWork unitOfWork,
                ICardService CardService
            ) : base(logger, unitOfWork)
            {
                this.CardService = CardService;
            }

            protected async override Task<Result<bool>> Act(RemoveLabelFromCardCommand request, CancellationToken cancellationToken)
            {
                return await this.CardService.RemoveLabelFromCard(request.CardId, request.LabelId, cancellationToken);
            }
        }
    }
}
