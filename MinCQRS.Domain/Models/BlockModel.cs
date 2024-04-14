using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class BlockModel : BaseModel
    {
        public required string Name { get; set; }

        public required BlockTemplateModel BlockTemplate { get; set; }

        public Collection<ElementModel>? Elements { get; set; }
    }
}
