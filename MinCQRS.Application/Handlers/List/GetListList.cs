﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.List
{
    public sealed class GetListListQuery : GetListQuery<ListModel>
    {
        public GetListListQuery() : base() { }

        public GetListListQuery(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter) : base(pageIndex, pageSize, sortBy, sortDir, filter) { }
    }

    public sealed class GetListListQueryValidator : AbstractValidator<GetListListQuery>
    {
        public GetListListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1).LessThan(100);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetListListHandler : BaseQueryHandler<GetListListHandler, GetListListQuery, IEnumerable<ListModel>>
    {
        private readonly IListService ListService;

        public GetListListHandler(
            ILogger<GetListListHandler> logger,
            IListService ListService
        ) : base(logger)
        {
            this.ListService = ListService;
        }

        protected async override Task<Result<IEnumerable<ListModel>>> Act(GetListListQuery request, CancellationToken cancellationToken)
        {
            return await ListService.GetList(request.PageIndex, request.PageSize, request.SortBy, request.SortDir, request.Filter);
        }
    }
}
