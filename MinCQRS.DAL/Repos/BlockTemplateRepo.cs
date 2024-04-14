using MinCQRS.DAL.Data;
using MinCQRS.DAL.Data.Interfaces;
using MinCQRS.DAL.Entities;

namespace MinCQRS.DAL.Repos
{
    public interface IBlockTemplateRepo : IBaseRepository<BlockTemplateEntity> { }

    public sealed class BlockTemplateRepo : BaseRepository<BlockTemplateEntity>, IBlockTemplateRepo
    {
        public BlockTemplateRepo(BaseDBContext context) : base(context)
        {

        }
    }
}
