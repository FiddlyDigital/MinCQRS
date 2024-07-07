using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class WorkspaceModel : BaseModel
    {
        public required string Name { get; set; }

        public Collection<BoardModel>? Boards { get; set; }
    }
}
