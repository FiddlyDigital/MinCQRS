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
    public sealed class DeleteCardCommand : DeleteCommand<CardModel>
    {
        public DeleteCardCommand() { }

        public DeleteCardCommand(int id) : base(id) { }
    }

    public sealed class DeleteCardQueryValidator : AbstractValidator<DeleteCardCommand>
    {
        public DeleteCardQueryValidator()
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
