using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IBoardRepo : IBaseRepository<BoardEntity> { }

    public sealed class BoardRepo : BaseRepository<BoardEntity>, IBoardRepo
    {
        public BoardRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
