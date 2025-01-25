using JobPortal.Core.Model;

namespace JobPortal.EmployerService.Domain
{
    public class Employer : BaseEntity
    {
        public Guid IdentityRefId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public short LimitOfJobPosts { get; set; }
    }
}
