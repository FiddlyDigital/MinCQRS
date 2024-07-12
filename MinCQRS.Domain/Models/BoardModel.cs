using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class BoardModel : BaseModel
    {
        public int WorkspaceId { get; set; }

        public Collection<ListModel>? Lists { get; set; }

        public BoardModel() 
        { 
            this.Lists = [];
        }
    }
}
