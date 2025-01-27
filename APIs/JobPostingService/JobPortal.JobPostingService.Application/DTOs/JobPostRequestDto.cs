using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.DTOs
{
    public class CreateJobPostRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public Guid EmployerId { get; set; }
        public Guid PositionId { get; set; }
        public Guid? WorkingMethodId { get; set; }
        public ICollection<Guid>? Benefits { get; set; }
    }
}