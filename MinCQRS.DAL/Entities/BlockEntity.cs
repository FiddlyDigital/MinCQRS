using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public  class BlockEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public required int BlockTemplateId { get; set; }

        public virtual required BlockTemplateEntity BlockTemplate { get; set; }

        public virtual ICollection<ElementEntity>? Elements { get; set; }
    }
}
