namespace JobPortal.Core.Events
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime CreatedDate { get; }
    }
} 