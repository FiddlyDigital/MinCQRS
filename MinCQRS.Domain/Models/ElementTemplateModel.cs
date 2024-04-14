using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class ElementTemplateModel : BaseModel
    {
        public required string Name { get; set; }
    }
}
