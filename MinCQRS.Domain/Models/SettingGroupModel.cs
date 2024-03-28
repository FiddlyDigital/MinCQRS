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
}
