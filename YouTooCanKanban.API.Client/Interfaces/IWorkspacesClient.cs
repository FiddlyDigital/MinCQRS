using Refit;
using YouTooCanKanban.API.Client.Models;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.API.Client.Interfaces
{
    public interface IWorkspacesClient: IApiClient<WorkspaceModel>
    {
        [Get("/api/v1/workspaces")]
        new Task<IEnumerable<WorkspaceModel>> GetList(GetListParams getListParams);

        [Get("/api/v1/workspaces/{workspaceId}")]
        new Task<WorkspaceModel> GetById(int workspaceId);

        [Post("/api/v1/workspaces/")]
        new Task<WorkspaceModel> Create([Body] WorkspaceModel newWorkspace);

        [Put("/api/v1/workspaces/{workspaceId}")]
        new Task Update(int workspaceId, [Body] WorkspaceModel updatedWorkspace);

        [Delete("/api/v1/workspaces/{workspaceId}")]
        new Task Delete(int workspaceId);
    }  
}
