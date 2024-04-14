namespace MinCQRS.DAL.Repos.Interfaces
{
    using MinCQRS.DAL.Data.Interfaces;
    using MinCQRS.DAL.Entities;

    public interface ISettingGroupsRepo : IBaseRepository<SettingGroupEntity> { }

    public interface IMicrositeRepo : IBaseRepository<MicrositeEntity> { }

    public interface IPageTemplateRepo : IBaseRepository<PageTemplateEntity> { }

    public interface IPageRepo : IBaseRepository<PageEntity> { }

    public interface IBlockTemplateRepo : IBaseRepository<BlockTemplateEntity> { }

    public interface IBlockRepo : IBaseRepository<BlockEntity> { }

    public interface IElementTemplateRepo : IBaseRepository<ElementTemplateEntity> { }

    public interface IElementRepo : IBaseRepository<ElementEntity> { }
}
