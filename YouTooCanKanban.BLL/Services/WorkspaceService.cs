using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
{
    public interface IWorkspaceService : ICrudService<WorkspaceService, WorkspaceModel>
    {

    }

    public sealed class WorkspaceService : CRUDService<WorkspaceService, WorkspaceModel, WorkspaceEntity>, IWorkspaceService
    {

        public WorkspaceService(ILogger<WorkspaceService> logger, IWorkspaceRepo repository) : base(logger, repository)
        {

        }
    }
}
