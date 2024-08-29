using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface IBoardRepo : IBaseRepository<BoardEntity> { }

    public sealed class BoardRepo : BaseRepository<BoardEntity>, IBoardRepo
    {
        private readonly string[] GetByIDIncludes = { nameof(BoardEntity.Lists), nameof(BoardEntity.Labels) };

        public BoardRepo(BaseDBContext context) : base(context) { }

        public override Task<BoardEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            return base.GetById(id, cancellationToken, GetByIDIncludes);
        }
    }
}
