using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Domain.Models
{
    public sealed class LabelModel : BaseModel
    {
        public int BoardId { get; set; }

        public required string HexColor { get; set; }

        public LabelModel() { }
    }
}
