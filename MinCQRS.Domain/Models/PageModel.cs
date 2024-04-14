using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class PageModel : BaseModel
    {
        public required string Name { get; set; }

        public required PageTemplateModel PageTemplate { get; set; }

        public Collection<BlockModel>? Blocks { get; set; }
    }
}
