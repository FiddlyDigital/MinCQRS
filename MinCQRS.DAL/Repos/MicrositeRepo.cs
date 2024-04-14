using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IMicrositeRepo : IBaseRepository<MicrositeEntity> { }

    public sealed class MicrositeRepo : BaseRepository<MicrositeEntity>, IMicrositeRepo
    {
        public MicrositeRepo(BaseDBContext context) : base(context)
        {
        }
    }
}
