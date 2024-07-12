using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.Card
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
            this.CardService = Cardervice;
        }

        protected async override Task<Result<CardModel?>> Act(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            return await CardService.GetById(request.Id, cancellationToken);
        }
    }
}
