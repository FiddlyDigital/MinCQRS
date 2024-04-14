using System.Collections.ObjectModel;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Domain.Models
{
    public sealed class MicrositeModel : BaseModel
    { 
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public Collection<PageModel>? Pages { get; set; }
    }
}
