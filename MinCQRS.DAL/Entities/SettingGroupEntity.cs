using MinCQRS.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MinCQRS.DAL.Entities
{
    public class SettingGroupEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }        

        public virtual ICollection<SettingGroupEntity>? SubGroups { get; set; }
    }
}
