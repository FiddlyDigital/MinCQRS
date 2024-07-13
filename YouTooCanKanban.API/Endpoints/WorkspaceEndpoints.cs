using YouTooCanKanban.API.Constants;
using YouTooCanKanban.API.Endpoints.Base;
using YouTooCanKanban.Application.Handlers.UseCases.Workspace;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Endpoints
{
    public sealed class GetWorkspaceListEndpoint : GetListEndpoint<GetWorkspaceListQuery, WorkspaceModel>, IEndpoint
    {
        public GetWorkspaceListEndpoint() : base(Resources.Routes.Workspaces) { }
    }

    public sealed class GetWorkspaceByIdEndpoint : GetByIdEndpoint<GetWorkspaceByIdQuery, WorkspaceModel>, IEndpoint
    {
        public GetWorkspaceByIdEndpoint() : base(Resources.Routes.Workspaces) { }
    }

    public sealed class CreateWorkspaceEndpoint : CreateEndpoint<CreateWorkspaceCommand, WorkspaceModel>, IEndpoint
    {
        public CreateWorkspaceEndpoint() : base(Resources.Routes.Workspaces) { }
    }

    public sealed class UpdateWorkspaceEndpoint : UpdateEndpoint<UpdateWorkspaceCommand, WorkspaceModel>, IEndpoint
    {
        public UpdateWorkspaceEndpoint() : base(Resources.Routes.Workspaces) { }
    }

    public sealed class DeleteWorkspaceEndpoint : DeleteEndpoint<DeleteWorkspaceCommand, WorkspaceModel>, IEndpoint
    {
        public DeleteWorkspaceEndpoint() : base(Resources.Routes.Workspaces) { }
    }
}
