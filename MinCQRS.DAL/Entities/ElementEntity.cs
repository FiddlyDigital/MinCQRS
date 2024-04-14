using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public  class ElementEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public required int ElementTemplateId { get; set; }

        public virtual required ElementTemplateEntity ElementTemplate { get; set; }
    }
}
