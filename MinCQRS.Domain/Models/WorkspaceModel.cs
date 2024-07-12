using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class WorkspaceModel : BaseModel
    {
        public Collection<BoardModel>? Boards { get; set; }

        public WorkspaceModel()
        {
            this.Boards = [];
        }
    }
}
