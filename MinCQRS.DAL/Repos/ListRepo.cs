using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IListRepo : IBaseRepository<ListEntity> { }

    public sealed class ListRepo : BaseRepository<ListEntity>, IListRepo
    {
        public ListRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
