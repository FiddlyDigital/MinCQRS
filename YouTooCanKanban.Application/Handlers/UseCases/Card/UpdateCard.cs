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
    public sealed class UpdateCardCommand : UpdateCommand<CardModel>
    {
        public UpdateCardCommand() { }

        public UpdateCardCommand(CardModel Card) : base(Card) { }
    }

    public sealed class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
            RuleFor(x => x.Model.ListId).GreaterThanOrEqualTo(1);
        }
    }

    public sealed class UpdateCardHandler : BaseCommandHandler<UpdateCardHandler, UpdateCardCommand, CardModel>
    {
        private readonly ICardService CardService;

        public UpdateCardHandler(
            ILogger<UpdateCardHandler> logger,
            IUnitOfWork unitOfWork,
            ICardService CardService
        ) : base(logger, unitOfWork)
        {
            this.CardService = CardService;
        }

        protected async override Task<Result<CardModel?>> Act(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            await CardService.Update(request.Model, cancellationToken);
            return null;
        }
    }
}
