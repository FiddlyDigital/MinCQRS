using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IBlockService : ICrudService<SettingGroupService, BlockModel>
    {

    }

    public sealed class BlockService : CRUDService<BlockService, BlockModel, BlockEntity>, IBlockService
    {
        public BlockService(ILogger<BlockService> logger, IBlockRepo repository) : base(logger, repository)
        {

        }
    }
}
