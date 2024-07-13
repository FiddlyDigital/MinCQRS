using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.Card
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
