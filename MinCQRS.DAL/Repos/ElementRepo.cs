using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IElementRepo : IBaseRepository<ElementEntity> { }

    public sealed class ElementRepo : BaseRepository<ElementEntity>, IElementRepo
    {
        public ElementRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
