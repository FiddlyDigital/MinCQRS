using System.Collections.ObjectModel;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Domain.Models
{
    public class CardModel : BaseModel
    {
        public int ListId { get; set; }

        public string? Description { get; set; }

        public string? Labels { get; set; }
    }
}
