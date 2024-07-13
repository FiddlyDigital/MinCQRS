using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Workspace
{
    public sealed class GetWorkspaceByIdQuery : GetByIdQuery<WorkspaceModel>
    {
        public GetWorkspaceByIdQuery() { }

        public GetWorkspaceByIdQuery(int id) : base(id) { }
    }

    public sealed class GetWorkspaceByIdQueryValidator : AbstractValidator<GetWorkspaceByIdQuery>
    {
        public GetWorkspaceByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class GetWorkspaceByIdHandler : BaseQueryHandler<GetWorkspaceByIdHandler, GetWorkspaceByIdQuery, WorkspaceModel>
    {
        private readonly IWorkspaceService WorkspaceService;

        public GetWorkspaceByIdHandler(
            ILogger<GetWorkspaceByIdHandler> logger,
            IWorkspaceService Workspaceervice
        ) : base(logger)
        {
            WorkspaceService = Workspaceervice;
        }

        protected async override Task<Result<WorkspaceModel?>> Act(GetWorkspaceByIdQuery request, CancellationToken cancellationToken)
        {
            return await WorkspaceService.GetById(request.Id, cancellationToken);
        }
    }
}
