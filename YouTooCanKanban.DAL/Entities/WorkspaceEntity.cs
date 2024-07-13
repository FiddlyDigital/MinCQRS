using YouTooCanKanban.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace YouTooCanKanban.DAL.Entities
{
    public class WorkspaceEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }        

        public virtual ICollection<BoardEntity>? Boards { get; set; }
    }
}
