using YouTooCanKanban.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace YouTooCanKanban.DAL.Entities
{
    public class BoardEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public int WorkspaceId { get; set; }

        public virtual WorkspaceEntity? Workspace { get; set; }

        public virtual ICollection<LabelEntity>? Labels { get; set; }

        public virtual ICollection<ListEntity>? Lists { get; set; }
    }
}
