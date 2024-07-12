using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public class ListModel : BaseModel
    {
        public int BoardId { get; set; }

        public required string Color { get; set; }

        public int SortOrder { get; set; }

        public Collection<CardModel>? Cards { get; set; }

        public ListModel()
        {
            this.Cards = [];
        }
    }
}
