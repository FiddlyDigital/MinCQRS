using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public class CardModel : BaseModel
    {
        public int ListId { get; set; }

        public string? Description { get; set; }

        public string? Labels { get; set; }
    }
}
