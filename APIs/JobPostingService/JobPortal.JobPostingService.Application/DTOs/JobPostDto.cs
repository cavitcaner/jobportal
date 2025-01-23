using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.DTOs
{
    public class JobPostResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime PostedDate { get; set; }
        public string WorkingMethod { get; set; }
        public string Position { get; set; }
        public List<string> Benefits { get; set; }
        public short JobPoint { get; set; }
    }
}