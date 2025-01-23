using JobPortal.Core.Model;

namespace JobPortal.JobPostingService.Domain.Entities
{
    public class Benefit : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<JobPost>? JobPosts { get; set; }
    }
} 