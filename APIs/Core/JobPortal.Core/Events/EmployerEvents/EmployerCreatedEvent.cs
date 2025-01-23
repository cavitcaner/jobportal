using JobPortal.Core.Statics;

namespace JobPortal.Core.Events.EmployerEvents
{
    public class EmployerCreatedEvent : IEvent
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public short LimitOfJobPosts { get; set; }
    }
} 