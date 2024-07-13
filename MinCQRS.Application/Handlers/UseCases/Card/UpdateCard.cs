using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.UseCases.Card
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
