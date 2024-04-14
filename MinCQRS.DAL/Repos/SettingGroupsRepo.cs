namespace MinCQRS.DAL.Repos
{
    using MinCQRS.DAL.Data;
    using MinCQRS.DAL.Entities;
    using MinCQRS.DAL.Repos.Interfaces;

    public sealed class SettingGroupsRepo : BaseRepository<SettingGroupEntity>, ISettingGroupsRepo
    {
        public SettingGroupsRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class MicrositeRepo : BaseRepository<MicrositeEntity>, IMicrositeRepo
    {
        public MicrositeRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class PageTemplateRepo : BaseRepository<PageTemplateEntity>, IPageTemplateRepo
    {
        public PageTemplateRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class PageRepo : BaseRepository<PageEntity>, IPageRepo
    {
        public PageRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class BlockTemplateRepo : BaseRepository<BlockTemplateEntity>, IBlockTemplateRepo
    {
        public BlockTemplateRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class BlockRepo : BaseRepository<BlockEntity>, IBlockRepo
    {
        public BlockRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class ElementTemplateRepo : BaseRepository<ElementTemplateEntity>, IElementTemplateRepo
    {
        public ElementTemplateRepo(BaseDBContext context) : base(context)
        {
        }
    }

    public sealed class ElementRepo : BaseRepository<ElementEntity>, IElementRepo
    {
        public ElementRepo(BaseDBContext context) : base(context)
        {
        }
    }
}
