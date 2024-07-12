using System.ComponentModel.DataAnnotations;
using MinCQRS.DAL.Entities.Base;

namespace MinCQRS.DAL.Entities
{
    public class ListEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public int BoardId { get; set; }

        public virtual BoardEntity? Board { get; set; }

        public virtual ICollection<CardEntity>? Cards { get; set; }
    }
}
