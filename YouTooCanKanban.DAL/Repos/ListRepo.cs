using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos.Base;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IListRepo : IBaseRepository<ListEntity> { }

    public sealed class ListRepo : BaseRepository<ListEntity>, IListRepo
    {
        private readonly string[] GetByIDIncludes = [nameof(ListEntity.Cards)];

        public ListRepo(BaseDBContext context) : base(context) { }

        public override Task<ListEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            return base.GetById(id, cancellationToken, GetByIDIncludes);
        }
    }
}
