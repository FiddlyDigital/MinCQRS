using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
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
