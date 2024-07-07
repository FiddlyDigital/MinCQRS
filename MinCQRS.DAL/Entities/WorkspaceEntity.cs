using MinCQRS.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MinCQRS.DAL.Entities
{
    public class WorkspaceEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }        

        public virtual ICollection<BoardEntity>? Boards { get; set; }
    }
}
