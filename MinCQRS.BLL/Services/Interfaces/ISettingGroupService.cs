namespace MinCQRS.BLL.Services.Interfaces
{
    using MinCQRS.BLL.Services.Base.Interfaces;
    using MinCQRS.Domain.Models;

    public interface ISettingGroupService : ICrudService<SettingGroupService, SettingGroupModel>
    {
    }

    public interface IMicrositeService : ICrudService<SettingGroupService, MicrositeModel>
    {
    }

    public interface IPageTemplateService : ICrudService<SettingGroupService, PageTemplateModel>
    {
    }

    public interface IPageService : ICrudService<SettingGroupService, PageModel>
    {
    }

    public interface IBlockTemplateService : ICrudService<SettingGroupService, BlockTemplateModel>
    {
    }

    public interface IBlockService : ICrudService<SettingGroupService, BlockModel>
    {
    }

    public interface IElementTemplateService : ICrudService<SettingGroupService, ElementTemplateModel>
    {
    }

    public interface IElementService : ICrudService<SettingGroupService, ElementModel>
    {
    }
}
