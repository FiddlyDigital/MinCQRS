namespace MinCQRS.BLL.Services
{
    using Microsoft.Extensions.Logging;
    using MinCQRS.BLL.Services.Base;
    using MinCQRS.BLL.Services.Interfaces;
    using MinCQRS.DAL.Entities;
    using MinCQRS.DAL.Repos.Interfaces;
    using MinCQRS.Domain.Models;

    public sealed class SettingGroupService : CRUDService<SettingGroupService, SettingGroupModel, SettingGroupEntity>, ISettingGroupService
    {
        public SettingGroupService(ILogger<SettingGroupService> logger, ISettingGroupsRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class MicrositeService : CRUDService<MicrositeService, MicrositeModel, MicrositeEntity>, IMicrositeService
    {
        public MicrositeService(ILogger<MicrositeService> logger, IMicrositeRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class PageTemplateService : CRUDService<PageTemplateService, PageTemplateModel, PageTemplateEntity>, IPageTemplateService
    {
        public PageTemplateService(ILogger<PageTemplateService> logger, IPageTemplateRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class PageService : CRUDService<PageService, PageModel, PageEntity>, IPageService
    {
        public PageService(ILogger<PageService> logger, IPageRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class BlockTemplateService : CRUDService<BlockTemplateService, BlockTemplateModel, BlockTemplateEntity>, IBlockTemplateService
    {
        public BlockTemplateService(ILogger<BlockTemplateService> logger, IBlockTemplateRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class BlockService : CRUDService<BlockService, BlockModel, BlockEntity>, IBlockService
    {
        public BlockService(ILogger<BlockService> logger, IBlockRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class ElementTemplateService : CRUDService<ElementTemplateService, ElementTemplateModel, ElementTemplateEntity>, IElementTemplateService
    {
        public ElementTemplateService(ILogger<ElementTemplateService> logger, IElementTemplateRepo repository) : base(logger, repository)
        {

        }
    }

    public sealed class ElementService : CRUDService<ElementService, ElementModel, ElementEntity>, IElementService
    {
        public ElementService(ILogger<ElementService> logger, IElementRepo repository) : base(logger, repository)
        {

        }
    }
}
