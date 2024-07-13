using YouTooCanKanban.DAL.Data;
using YouTooCanKanban.DAL.Data.Interfaces;
using YouTooCanKanban.DAL.Entities;

namespace YouTooCanKanban.DAL.Repos
{
    public interface ICardRepo : IBaseRepository<CardEntity> { }

    public sealed class CardRepo : BaseRepository<CardEntity>, ICardRepo
    {
        public CardRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
