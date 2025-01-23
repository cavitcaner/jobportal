namespace JobPortal.Core.Model
{
    public interface ISoftDeletable
    {
        DateTime? DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
