namespace MinCQRS.DAL.Entities
{
    using MinCQRS.DAL.Entities.Base;
    using System.ComponentModel.DataAnnotations;

    public class SettingGroupEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }        

        public virtual ICollection<SettingGroupEntity>? SubGroups { get; set; }
    }
}
