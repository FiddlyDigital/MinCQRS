﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Card
{
    public sealed class GetCardListQuery : GetListQuery<CardModel>
    {
        public GetCardListQuery() : base() { }

        public GetCardListQuery(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter) : base(pageIndex, pageSize, sortBy, sortDir, filter) { }
    }

    public sealed class GetCardListQueryValidator : AbstractValidator<GetCardListQuery>
    {
        public GetCardListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetCardListHandler : BaseQueryHandler<GetCardListHandler, GetCardListQuery, IEnumerable<CardModel>>
    {
        private readonly ICardService CardService;

        public GetCardListHandler(
            ILogger<GetCardListHandler> logger,
            ICardService CardService
        ) : base(logger)
        {
            this.CardService = CardService;
        }

        protected async override Task<Result<IEnumerable<CardModel>>> Act(GetCardListQuery request, CancellationToken cancellationToken)
        {
            return await CardService.GetList(request.PageIndex, request.PageSize, request.SortBy, request.SortDir, request.Filter);
        }
    }
}
