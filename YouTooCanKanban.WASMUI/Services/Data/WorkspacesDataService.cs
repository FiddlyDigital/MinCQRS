using YouTooCanKanban.API.Client.Interfaces;
using YouTooCanKanban.Domain.Models;
using YouTooCanKanban.WASMUI.Services.Data.Base;

namespace YouTooCanKanban.WASMUI.Services.Data
{
    public interface IWorkspacesDataService : ICRUDDataService<WorkspaceModel> { }

    public sealed class WorkspacesDataService : CRUDDataService<WorkspacesDataService, IWorkspacesClient, WorkspaceModel>, IWorkspacesDataService
    {
        public WorkspacesDataService(
            IWorkspacesClient client,
            ILogger<WorkspacesDataService> logger
        ) : base(client, logger)
        {
        }
    }
}
