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
    public sealed class UpdateWorkspaceCommand : UpdateCommand<WorkspaceModel>
    {
        public UpdateWorkspaceCommand() { }

        public UpdateWorkspaceCommand(WorkspaceModel Workspace) : base(Workspace) { }
    }

    public sealed class UpdateWorkspaceQueryValidator : AbstractValidator<UpdateWorkspaceCommand>
    {
        public UpdateWorkspaceQueryValidator()
        {
            RuleFor(x => x.Model).NotNull();
        }
    }

    public sealed class UpdateWorkspaceHandler : BaseCommandHandler<UpdateWorkspaceHandler, UpdateWorkspaceCommand, WorkspaceModel>
    {
        private readonly IWorkspaceService WorkspaceService;

        public UpdateWorkspaceHandler(
            ILogger<UpdateWorkspaceHandler> logger,
            IUnitOfWork unitOfWork,
            IWorkspaceService WorkspaceService
        ) : base(logger, unitOfWork)
        {
            this.WorkspaceService = WorkspaceService;
        }

        protected async override Task<Result<WorkspaceModel?>> Act(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            await WorkspaceService.Update(request.Model, cancellationToken);
            return null;
        }
    }
}
