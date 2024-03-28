namespace MinCQRS.DAL.Entities.Base
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity : ISoftDeletable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAtUtc { get; set; } = null;
    }
}
