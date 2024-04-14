using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public class PageEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public required int PageTemplateId { get; set; }

        public virtual required PageTemplateEntity PageTemplate { get; set; }

        public virtual ICollection<BlockEntity>? Blocks { get; set; }
    }
}
