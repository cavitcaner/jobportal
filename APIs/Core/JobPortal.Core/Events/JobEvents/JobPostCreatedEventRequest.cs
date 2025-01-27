namespace JobPortal.Core.Events.JobEvents
{
    public class JobPostCreatedEventRequest : IEvent
    {
        public Guid EmployerId { get; set; }
    }
} 