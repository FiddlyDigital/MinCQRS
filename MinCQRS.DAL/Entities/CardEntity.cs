using MinCQRS.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MinCQRS.DAL.Entities
{
    public class CardEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public int ListId { get; set; }

        public virtual ListEntity? List { get; set; }
    }
}
