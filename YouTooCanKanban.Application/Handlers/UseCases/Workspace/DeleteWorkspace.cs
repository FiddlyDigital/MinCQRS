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
    public sealed class DeleteWorkspaceCommand : DeleteCommand<WorkspaceModel>
    {
        public DeleteWorkspaceCommand() { }

        public DeleteWorkspaceCommand(int id) : base(id) { }
    }

    public sealed class DeleteWorkspaceQueryValidator : AbstractValidator<DeleteWorkspaceCommand>
    {
        public DeleteWorkspaceQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public sealed class DeleteWorkspaceHandler : BaseCommandHandler<DeleteWorkspaceHandler, DeleteWorkspaceCommand, WorkspaceModel>
    {
        private readonly IWorkspaceService WorkspaceService;

        public DeleteWorkspaceHandler(
            ILogger<DeleteWorkspaceHandler> logger,
            IUnitOfWork unitOfWork,
            IWorkspaceService WorkspaceService
        ) : base(logger, unitOfWork)
        {
            this.WorkspaceService = WorkspaceService;
        }

        protected async override Task<Result<WorkspaceModel?>> Act(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
        {
            await WorkspaceService.Delete(request.Id, cancellationToken);
            return null;
        }
    }
}
