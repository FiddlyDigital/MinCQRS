using System.Collections.ObjectModel;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Domain.Models
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
