using System.Collections.ObjectModel;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Domain.Models
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
