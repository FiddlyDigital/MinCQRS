using MinCQRS.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MinCQRS.DAL.Entities
{
    public class BoardEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }
    }
}
