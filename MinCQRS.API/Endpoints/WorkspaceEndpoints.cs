using MinCQRS.API.Constants;
using MinCQRS.API.Endpoints.Base;
using MinCQRS.Application.Handlers.Workspace;
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
}
