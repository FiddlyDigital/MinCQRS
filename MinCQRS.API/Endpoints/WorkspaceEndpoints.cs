using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.UseCases.Workspace;
using MinCQRS.Domain.Models;

namespace MinCQRS.API.Endpoints
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
