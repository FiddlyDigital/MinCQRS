using FluentValidation;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.Application.Handlers.Base.GenericQueries;
using YouTooCanKanban.Application.Handlers.Base;
using YouTooCanKanban.BLL.Services;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.DAL.Data.Interfaces;

namespace YouTooCanKanban.Application.Handlers.UseCases.Workspace
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
            RuleFor(x => x.Model.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Model.Name).NotNull().NotEmpty();
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
