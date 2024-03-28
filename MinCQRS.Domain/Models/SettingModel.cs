namespace MinCQRS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using MinCQRS.Domain.Models.Base;

    public sealed class SettingModel : BaseModel
    {
        [Required]
        public required string Key { get; set; }

        [Required]
        public required string Value { get; set; }

        public bool IsPrivate { get; set; }
    }
}
