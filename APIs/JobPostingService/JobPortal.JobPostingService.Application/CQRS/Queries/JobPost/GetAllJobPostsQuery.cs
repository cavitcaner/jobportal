using MediatR;
using AutoMapper;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.Interfaces;

namespace JobPortal.JobPostingService.Application.CQRS.Queries.JobPost
{
    /// <summary>
    /// ilan süresi henüz dolmamýþ bütün ilan listesini döner
    /// </summary>
    public class GetAllJobPostsQuery : MediatR.IRequest<List<JobPostResponseDto>>
    {
    }

    public class GetAllJobPostsQueryHandler : IRequestHandler<GetAllJobPostsQuery, List<JobPostResponseDto>>
    {
        private readonly IJobPostElasticService _jobPostElasticService;
        private readonly IMapper _mapper;

        public GetAllJobPostsQueryHandler(IMapper mapper, IJobPostElasticService jobPostElasticService)
        {
            _mapper = mapper;
            _jobPostElasticService = jobPostElasticService;
        }

        public async Task<List<JobPostResponseDto>> Handle(GetAllJobPostsQuery request, CancellationToken cancellationToken)
        {
            var jobPosts = await _jobPostElasticService.GetAllDataAsync(cancellationToken);
            return _mapper.Map<List<JobPostResponseDto>>(jobPosts);
        }
    }
}