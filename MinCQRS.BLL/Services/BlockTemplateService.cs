using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IBlockTemplateService : ICrudService<SettingGroupService, BlockTemplateModel>
    {

    }
    public sealed class BlockTemplateService : CRUDService<BlockTemplateService, BlockTemplateModel, BlockTemplateEntity>, IBlockTemplateService
    {
        public BlockTemplateService(ILogger<BlockTemplateService> logger, IBlockTemplateRepo repository) : base(logger, repository)
        {

        }
    }
}
