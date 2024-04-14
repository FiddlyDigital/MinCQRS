using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class ElementModel : BaseModel
    {
        public required string Name { get; set; }

        public required ElementTemplateModel ElementTemplate { get; set; }
    }
}
