using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;

namespace MinCQRS.Application.Handlers.UseCases.Workspace
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
