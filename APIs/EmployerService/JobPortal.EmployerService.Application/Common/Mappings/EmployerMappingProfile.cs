using AutoMapper;
using JobPortal.EmployerService.Application.DTOs;
using JobPortal.EmployerService.Domain.Entities;

namespace JobPortal.EmployerService.Application.Common.Mappings
{
    public class EmployerMappingProfile : Profile
    {
        public EmployerMappingProfile()
        {
            CreateMap<Employer, GetEmployerResponseDto>();
            CreateMap<Employer, GetEmployerDetailResponseDto>();
            CreateMap<CreateEmployerRequestDto, Employer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}