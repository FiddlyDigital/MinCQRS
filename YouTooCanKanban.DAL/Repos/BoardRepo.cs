using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IBoardRepo : IBaseRepository<BoardEntity> { }

    public sealed class BoardRepo : BaseRepository<BoardEntity>, IBoardRepo
    {
        public BoardRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
