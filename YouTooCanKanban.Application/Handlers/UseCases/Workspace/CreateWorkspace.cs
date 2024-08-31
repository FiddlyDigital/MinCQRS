using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.Application.Handlers.Base.GenericCommands;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.Application.Handlers.UseCases.Workspace
{
    public sealed class CreateWorkspaceCommand : CreateCommand<WorkspaceModel>
    {
        public CreateWorkspaceCommand() { }

        public CreateWorkspaceCommand(WorkspaceModel workspace) : base(workspace) { }
    }

    public sealed class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        public CreateWorkspaceCommandValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Model.Id).LessThanOrEqualTo(0).GreaterThanOrEqualTo(-1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
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
