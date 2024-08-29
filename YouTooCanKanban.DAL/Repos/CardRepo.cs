using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface ICardRepo : IBaseRepository<CardEntity> { }

    public sealed class CardRepo : BaseRepository<CardEntity>, ICardRepo
    {
        private readonly string[] GetByIDIncludes = [nameof(CardEntity.Labels)];

        public CardRepo(BaseDBContext context) : base(context) { }

        public override Task<CardEntity?> GetById(int id, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            return base.GetById(id, cancellationToken, GetByIDIncludes);
        }
    }
}
