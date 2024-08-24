using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class AddLabelToCardCommand : ICommand<Result<bool>>
    {
        public int LabelId { get; set; }
        public int CardId { get; set; }

        public AddLabelToCardCommand() { }

        public AddLabelToCardCommand(int labelId, int cardId)
        {
            LabelId = labelId;
            CardId = cardId;
        }
    }

    public sealed class AddLabelToCardCommandValidator : AbstractValidator<AddLabelToCardCommand>
    {
        public AddLabelToCardCommandValidator()
        {
            RuleFor(x => x.LabelId).GreaterThan(0);
            RuleFor(x => x.CardId).GreaterThan(0);
        }

        public sealed class AddLabelToCardHandler : BaseCommandHandler<AddLabelToCardHandler, AddLabelToCardCommand, bool>
        {
            private readonly ICardService CardService;

            public AddLabelToCardHandler(
                ILogger<AddLabelToCardHandler> logger,
                IUnitOfWork unitOfWork,
                ICardService CardService
            ) : base(logger, unitOfWork)
            {
                this.CardService = CardService;
            }

            protected async override Task<Result<bool>> Act(AddLabelToCardCommand request, CancellationToken cancellationToken)
            {
                return await CardService.AddLabelToCard(request.CardId, request.LabelId, cancellationToken);
            }
        }
    }
}
