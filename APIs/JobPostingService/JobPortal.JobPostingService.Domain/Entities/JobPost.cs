using JobPortal.Core.Model;

namespace JobPortal.JobPostingService.Domain.Entities
{
    public class JobPost : BaseEntity, ISoftDeletable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployerId { get; set; }
        public string? Requirements { get; set; }
        public string CompanyName { get; set; }
        public string? Location { get; set; }
        public decimal? Salary { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public Position? Position { get; set; }
        public Guid? PositionId { get; set; }
        public WorkingMethod? WorkingMethod { get; set; }
        public Guid? WorkingMethodId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}