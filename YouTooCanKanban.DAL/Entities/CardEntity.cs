using YouTooCanKanban.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace YouTooCanKanban.DAL.Entities
{
    public class CardEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public int ListId { get; set; }

        public virtual ListEntity? List { get; set; }

        public virtual ICollection<LabelEntity>? Labels { get; set; }
    }
}
