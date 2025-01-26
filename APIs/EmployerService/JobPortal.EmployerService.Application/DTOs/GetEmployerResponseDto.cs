namespace JobPortal.EmployerService.Application.DTOs
{
    public class GetEmployerResponseDto {

        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
    }
}
