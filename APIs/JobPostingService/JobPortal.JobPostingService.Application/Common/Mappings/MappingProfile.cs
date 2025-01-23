using AutoMapper;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Benefit, BenefitDto>();
        }
    }
} 