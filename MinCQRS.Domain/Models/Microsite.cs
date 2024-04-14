using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class Microsite : BaseModel
    {
        public required string Name { get; set; } 
    }
}
