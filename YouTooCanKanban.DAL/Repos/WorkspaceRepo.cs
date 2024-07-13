using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IWorkspaceRepo : IBaseRepository<WorkspaceEntity> { }

    public sealed class WorkspaceRepo : BaseRepository<WorkspaceEntity>, IWorkspaceRepo
    {
        public WorkspaceRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
