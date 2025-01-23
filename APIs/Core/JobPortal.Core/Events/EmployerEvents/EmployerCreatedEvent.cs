using JobPortal.Core.Statics;

namespace JobPortal.Core.Events.EmployerEvents
{
    public class EmployerCreatedEvent
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public short LimitOfJobPosts { get; set; }
        public DateTime CreatedDate { get; set; }

        public EmployerCreatedEvent(Guid id, string companyName, string email, string phone)
        {
            Id = id;
            CompanyName = companyName;
            Phone = phone;
            CreatedDate = DateTime.UtcNow;
            LimitOfJobPosts = EmployerStatics.DefaultLimitOfJobPosts;
        }
    }
} 