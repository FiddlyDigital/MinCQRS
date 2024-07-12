using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface ICardRepo : IBaseRepository<CardEntity> { }

    public sealed class CardRepo : BaseRepository<CardEntity>, ICardRepo
    {
        public CardRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
