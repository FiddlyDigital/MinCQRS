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
            ICardService CardService,
            IListService ListService
        ) : base(logger, unitOfWork)
        {
            this.CardService = CardService;
            this.ListService = ListService;
        }

        protected async override Task<Result<CardModel?>> Act(CreateCardCommand request, CancellationToken cancellationToken)
        {
            Result<ListModel?> retriveExistingList = await this.ListService.GetById(request.Model.ListId, cancellationToken);
            if (!retriveExistingList.IsSuccess)
            {
                return new Result<CardModel>(new Exception("List does not exist, cannot create Card"));
            }

            return await CardService.Create(request.Model, cancellationToken);            
        }
    }
}
