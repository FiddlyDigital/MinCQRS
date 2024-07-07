using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IWorkspaceRepo : IBaseRepository<WorkspaceEntity> { }

    public sealed class WorkspaceRepo : BaseRepository<WorkspaceEntity>, IWorkspaceRepo
    {
        public WorkspaceRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
