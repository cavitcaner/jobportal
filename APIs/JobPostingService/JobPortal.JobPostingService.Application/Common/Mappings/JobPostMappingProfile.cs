using AutoMapper;
using JobPortal.Core.Events.JobEvents;
using JobPortal.JobPostingService.Application.CQRS.Commands.JobPost;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Domain.Entities;

namespace JobPortal.JobPostingService.Application.Common.Mappings
{
    public class JobPostMappingProfile : Profile
    {
        public JobPostMappingProfile()
        {
            CreateMap<Benefit, BenefitDto>();
            CreateMap<JobPostCreatedEvent, JobPost>();

            CreateMap<CreateJobPostRequestDto, JobPost>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Benefits, opt => opt.Ignore());

            CreateMap<JobPost, CreateJobPostRequestDto>();
            CreateMap<JobPostElasticModel, JobPostResponseDto>();
            CreateMap<JobPost, JobPostElasticModel>()
                .ForMember(x => x.PostedDate, x => x.MapFrom(c => c.CreatedDate))
                .ForMember(x => x.Benefits, x => x.MapFrom(c => c.Benefits == null ? new List<string>() : c.Benefits.Select(c => c.Name).ToList()))
                .ReverseMap();
        }
    }
}