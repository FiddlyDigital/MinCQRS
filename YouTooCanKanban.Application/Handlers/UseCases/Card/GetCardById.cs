using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class GetCardByIdQuery : GetByIdQuery<CardModel>
    {
        public GetCardByIdQuery() { }

        public GetCardByIdQuery(int id) : base(id) { }
    }

    public sealed class GetCardByIdQueryValidator : AbstractValidator<GetCardByIdQuery>
    {
        public GetCardByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetCardByIdHandler : BaseQueryHandler<GetCardByIdHandler, GetCardByIdQuery, CardModel>
    {
        private readonly ICardService CardService;

        public GetCardByIdHandler(
            ILogger<GetCardByIdHandler> logger,
            ICardService Cardervice
        ) : base(logger)
        {
            CardService = Cardervice;
        }

        protected async override Task<Result<CardModel?>> Act(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            return await CardService.GetById(request.Id, cancellationToken);
        }
    }
}
