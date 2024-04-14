using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IPageRepo : IBaseRepository<PageEntity> { }

    public sealed class PageRepo : BaseRepository<PageEntity>, IPageRepo
    {
        public PageRepo(BaseDBContext context) : base(context)
        {
        }
    }
}
