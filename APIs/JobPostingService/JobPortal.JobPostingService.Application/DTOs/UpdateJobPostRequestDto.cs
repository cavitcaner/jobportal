namespace JobPortal.JobPostingService.Application.DTOs
{
    public class UpdateJobPostRequestDto : CreateJobPostRequestDto
    {
        public Guid Id { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}