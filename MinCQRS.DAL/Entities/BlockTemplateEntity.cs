using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public class BlockTemplateEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }
    }
}
