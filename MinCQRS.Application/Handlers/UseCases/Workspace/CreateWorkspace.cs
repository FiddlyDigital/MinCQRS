using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MinCQRS.Application.Handlers.Base.GenericQueries;
using MinCQRS.Application.Handlers.Base;
using MinCQRS.BLL.Services;
using MinCQRS.Domain.Models;
using MinCQRS.DAL.Data.Interfaces;

namespace MinCQRS.Application.Handlers.UseCases.Workspace
{
    public sealed class CreateWorkspaceCommand : CreateCommand<WorkspaceModel>
    {
        public CreateWorkspaceCommand() { }

        public CreateWorkspaceCommand(WorkspaceModel workspace) : base(workspace) { }
    }

    public sealed class CreateWorkspaceQueryValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        public CreateWorkspaceQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
        }
    }

    public sealed class CreateWorkspaceHandler : BaseCommandHandler<CreateWorkspaceHandler, CreateWorkspaceCommand, WorkspaceModel>
    {
        private readonly IWorkspaceService WorkspaceService;

        public CreateWorkspaceHandler(
            ILogger<CreateWorkspaceHandler> logger,
            IUnitOfWork unitOfWork,
            IWorkspaceService workspaceService
        ) : base(logger, unitOfWork)
        {
            WorkspaceService = workspaceService;
        }

        protected async override Task<Result<WorkspaceModel?>> Act(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            return await WorkspaceService.Create(request.Model, cancellationToken);
        }
    }
}
