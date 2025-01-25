namespace JobPortal.Core.Events.JobEvents
{
    public class JobPostCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public decimal? Salary { get; set; }
        public Guid? PositionId { get; set; }
        public ICollection<Guid>? BenefitsId { get; set; }
        public Guid? WorkingMethodId { get; set; }
    }
} 