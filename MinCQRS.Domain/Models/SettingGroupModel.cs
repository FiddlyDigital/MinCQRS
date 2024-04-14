namespace MinCQRS.Domain.Models
{
    using MinCQRS.Domain.Models.Base;
    using System.Collections.ObjectModel;

    public sealed class SettingGroupModel : BaseModel
    {
        public required string Name { get; set; }
        public Collection<SettingGroupModel>? SubGroups { get; set; }
        public Collection<SettingModel>? Settings { get; set; }
    }

    public sealed class MicrositeModel : BaseModel
    { 
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public Collection<PageModel>? Pages { get; set; }
    }

    public sealed class PageTemplateModel : BaseModel
    {
        public required string Name { get; set; }
    }

    public sealed class PageModel : BaseModel
    {
        public required string Name { get; set; }

        public required PageTemplateModel PageTemplate { get; set; }

        public Collection<BlockModel>? Blocks { get; set; }
    }

    public sealed class BlockTemplateModel : BaseModel
    {
        public required string Name { get; set; }
    }

    public sealed class BlockModel : BaseModel
    {
        public required string Name { get; set; }

        public required BlockTemplateModel BlockTemplate { get; set; }

        public Collection<ElementModel>? Elements { get; set; }
    }

    public sealed class ElementTemplateModel : BaseModel
    {
        public required string Name { get; set; }
    }

    public sealed class ElementModel : BaseModel
    {
        public required string Name { get; set; }

        public required ElementTemplateModel ElementTemplate { get; set; }
    }
}
