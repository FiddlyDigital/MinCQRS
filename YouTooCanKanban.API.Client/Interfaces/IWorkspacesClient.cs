using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface IWorkspacesClient
    {
        [Get("/api/v1/workspaces")]
        Task<IEnumerable<WorkspaceModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/workspaces/{workspaceId}")]
        Task<WorkspaceModel> GetById(int workspaceId);

        [Post("/api/v1/workspaces/")]
        Task<WorkspaceModel> Create([Body] WorkspaceModel newWorkspace);

        [Put("/api/v1/workspaces/{workspaceId}")]
        Task Update(int workspaceId, [Body] WorkspaceModel updatedWorkspace);

        [Delete("/api/v1/workspaces/{workspaceId}")]
        Task Delete(int workspaceId);
    }
}
