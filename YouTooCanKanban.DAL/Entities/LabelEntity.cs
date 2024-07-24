using System.ComponentModel.DataAnnotations;
using YouTooCanKanban.DAL.Entities.Base;

namespace YouTooCanKanban.DAL.Entities
{
    public class LabelEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public required string HexColor { get; set; }

        public int BoardId { get; set; }

        public virtual BoardEntity? Board { get; set; }

        public virtual ICollection<CardEntity>? Cards { get; set; }
    }
}
