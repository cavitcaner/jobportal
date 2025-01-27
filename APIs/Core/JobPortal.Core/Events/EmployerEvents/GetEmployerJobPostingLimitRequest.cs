
namespace JobPortal.Core.Events.EmployerEvents
{
    public class GetEmployerJobPostingLimitEventRequest
    {
        public Guid EmployerId { get; set; }
    }

    public class GetEmployerJobPostingLimitEventResponse
    {
        public Guid EmployerId { get; set; }
        public int LimitOfJobPosting { get; set; }
        public string CompanyName { get; set; }
    }
}
