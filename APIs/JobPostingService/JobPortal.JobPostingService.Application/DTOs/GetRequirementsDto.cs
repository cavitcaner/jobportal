namespace JobPortal.JobPostingService.Application.DTOs
{
    public class RequirementsDto
    {
        public ICollection<ParameterDto> Benefits { get; set; }
        public ICollection<ParameterDto> WorkingMethods { get; set; }
        public ICollection<ParameterDto> Positions { get; set; }
    }
}