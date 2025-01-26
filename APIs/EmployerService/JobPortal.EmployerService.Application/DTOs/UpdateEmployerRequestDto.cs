using System.Text.Json.Serialization;

namespace JobPortal.EmployerService.Application.DTOs
{
    public class UpdateEmployerRequestDto : CreateEmployerRequestDto
    {
        public Guid Id;
        public short? LimitOfJobPosts { get; set; }
    }
}
