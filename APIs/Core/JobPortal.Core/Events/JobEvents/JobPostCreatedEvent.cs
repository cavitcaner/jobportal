namespace JobPortal.Core.Events.JobEvents
{
    public class JobPostCreatedEvent
    {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public float? Salary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? PositionId { get; set; }
        public int? BenefitsId { get; set; }
        public int? WorkingMethodId { get; set; }

        public JobPostCreatedEvent(Guid id, Guid employerId, string title, string description, 
            string companyName, float? salary, int? positionId, int? benefitsId, int? workingMethodId)
        {
            Id = id;
            EmployerId = employerId;
            Title = title;
            Description = description;
            CompanyName = companyName;
            Salary = salary;
            CreatedDate = DateTime.UtcNow;
            PositionId = positionId;
            BenefitsId = benefitsId;
            WorkingMethodId = workingMethodId;
        }
    }
} 