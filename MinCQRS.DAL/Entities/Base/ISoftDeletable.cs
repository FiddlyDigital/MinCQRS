namespace MinCQRS.DAL.Entities.Base
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedAtUtc { get; set; }
    }
}
