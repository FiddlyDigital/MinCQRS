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
    public sealed class CreateCardCommand : CreateCommand<CardModel>
    {
        public CreateCardCommand() { }

        public CreateCardCommand(CardModel Card) : base(Card) { }
    }

    public sealed class CreateCardQueryValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
        }
    }

    public sealed class CreateCardHandler : BaseCommandHandler<CreateCardHandler, CreateCardCommand, CardModel>
    {
        private readonly ICardService CardService;

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
            return await CardService.Create(request.Model, cancellationToken);
        }
    }
}
