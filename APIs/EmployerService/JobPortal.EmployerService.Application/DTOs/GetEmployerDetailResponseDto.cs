namespace JobPortal.EmployerService.Application.DTOs
{
    public class GetEmployerDetailResponseDto : GetEmployerResponseDto {
        public Guid IdentityRefId { get; set; }
        public short LimitOfJobPosts { get; set; }
    }
}
