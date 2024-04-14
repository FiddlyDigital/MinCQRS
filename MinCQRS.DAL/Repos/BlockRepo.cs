using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IBlockRepo : IBaseRepository<BlockEntity> { }

    public sealed class BlockRepo : BaseRepository<BlockEntity>, IBlockRepo
    {
        public BlockRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
