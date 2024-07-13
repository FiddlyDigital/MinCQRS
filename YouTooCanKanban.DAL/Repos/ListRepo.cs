using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IListRepo : IBaseRepository<ListEntity> { }

    public sealed class ListRepo : BaseRepository<ListEntity>, IListRepo
    {
        public ListRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
