using JobPortal.Core.Model;

namespace JobPortal.JobPostingService.Domain.Entities
{
    public class JobPost : BaseEntity, ISoftDeletable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployerId { get; set; }
        public string CompanyName { get; set; }
        public decimal? Salary { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public Position? Position { get; set; }
        public int? PositionId { get; set; }
        public WorkingMethod? WorkingMethod { get; set; }
        public int? WorkingMethodId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}