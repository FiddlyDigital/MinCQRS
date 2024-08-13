using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IWorkspaceRepo : IBaseRepository<WorkspaceEntity> { }

    public sealed class WorkspaceRepo : BaseRepository<WorkspaceEntity>, IWorkspaceRepo
    {
        private readonly string[] GetByIDIncludes = { nameof(WorkspaceEntity.Boards) };

        public WorkspaceRepo(BaseDBContext context) : base(context)
        {

        }

        public override Task<WorkspaceEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            return base.GetById(id, cancellationToken, GetByIDIncludes);
        }
    }
}
