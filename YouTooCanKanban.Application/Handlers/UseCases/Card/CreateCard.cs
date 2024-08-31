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
    public sealed class CreateCardCommand : CreateCommand<CardModel>
    {
        public CreateCardCommand() { }

        public CreateCardCommand(CardModel Card) : base(Card) { }
    }

    public sealed class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).LessThanOrEqualTo(0).GreaterThanOrEqualTo(-1);
            RuleFor(x => x.Model.ListId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
        }
    }

    public sealed class CreateCardHandler : BaseCommandHandler<CreateCardHandler, CreateCardCommand, CardModel>
    {
        private readonly ICardService CardService;
        private readonly IListService ListService;

        public CreateCardHandler(
            ILogger<CreateCardHandler> logger,
            IUnitOfWork unitOfWork,
            ICardService CardService
        ) : base(logger, unitOfWork)
        {
            this.CardService = CardService;
        }

        protected async override Task<Result<CardModel?>> Act(CreateCardCommand request, CancellationToken cancellationToken)
        {
            Result<CardModel?> newCardResult = await CardService.Create(request.Model, cancellationToken);
            return newCardResult.Match(
                Succ: newCard => newCard,
                Fail: exc => new Result<CardModel?>(new Exception("Could not create Card", exc)));
        }
    }
}
