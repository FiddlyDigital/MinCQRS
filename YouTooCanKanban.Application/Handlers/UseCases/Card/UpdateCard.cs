using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class UpdateCardCommand : UpdateCommand<CardModel>
    {
        public UpdateCardCommand() { }

        public UpdateCardCommand(CardModel Card) : base(Card) { }
    }

    public sealed class UpdateCardQueryValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
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
