using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public class MicrositeEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<PageEntity>? Pages { get; set; }

    }
}
