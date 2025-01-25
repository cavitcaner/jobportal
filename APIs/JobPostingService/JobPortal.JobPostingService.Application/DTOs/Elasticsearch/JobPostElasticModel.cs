using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.DTOs.Elasticsearch
{
    public class JobPostElasticModel
    {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public Guid CompanyId { get; set; }
        public string? Requirements { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string? Location { get; set; }
        public decimal? Salary { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string WorkingMethod { get; set; }
        public string Position { get; set; }
        public List<string> Benefits { get; set; }
        public short JobPoint { get; set; }
    }
}