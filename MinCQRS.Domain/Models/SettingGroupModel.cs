using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class SettingGroupModel : BaseModel
    {
        public required string Name { get; set; }
        public Collection<SettingGroupModel>? SubGroups { get; set; }
        public Collection<SettingModel>? Settings { get; set; }
    }
}
