﻿using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Workspace
{
    public sealed class GetWorkspaceListQuery : GetListQuery<WorkspaceModel>
    {
        public GetWorkspaceListQuery() : base() { }

        public GetWorkspaceListQuery(int pageIndex, int pageSize, string? sortBy, string? sortDir, string? filter) : base(pageIndex, pageSize, sortBy, sortDir, filter) { }
    }

    public sealed class GetWorkspaceListQueryValidator : AbstractValidator<GetWorkspaceListQuery>
    {
        public GetWorkspaceListQueryValidator()
        {
            RuleFor(x => x.PageIndex).GreaterThan(-1);
            RuleFor(x => x.PageSize).GreaterThan(-1).LessThanOrEqualTo(50);
        }
    }

    public sealed class GetWorkspaceListHandler : BaseQueryHandler<GetWorkspaceListHandler, GetWorkspaceListQuery, IEnumerable<WorkspaceModel>>
    {
        private readonly IWorkspaceService WorkspaceService;

        public GetWorkspaceListHandler(
            ILogger<GetWorkspaceListHandler> logger,
            IWorkspaceService WorkspaceService
        ) : base(logger)
        {
            this.WorkspaceService = WorkspaceService;
        }

        protected async override Task<Result<IEnumerable<WorkspaceModel>>> Act(GetWorkspaceListQuery request, CancellationToken cancellationToken)
        {
            return await WorkspaceService.GetList(request.PageIndex, request.PageSize, request.SortBy, request.SortDir, request.Filter);
        }
    }
}
