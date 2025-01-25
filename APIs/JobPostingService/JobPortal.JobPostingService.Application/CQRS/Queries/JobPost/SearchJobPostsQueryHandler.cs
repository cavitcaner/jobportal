using MediatR;
using AutoMapper;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.Interfaces;

namespace JobPortal.JobPostingService.Application.CQRS.Queries.JobPost
{
    public class SearchJobPostsQuery : MediatR.IRequest<List<JobPostResponseDto>>
    {
        public string Query { get; set; }
    }

    public class SearchJobPostsQueryHandler : IRequestHandler<SearchJobPostsQuery, List<JobPostResponseDto>>
    {
        private readonly IJobPostElasticService _jobPostElasticService;
        private readonly IMapper _mapper;

        public SearchJobPostsQueryHandler(IMapper mapper, IJobPostElasticService jobPostElasticService)
        {
            _mapper = mapper;
            _jobPostElasticService = jobPostElasticService;
        }

        public async Task<List<JobPostResponseDto>> Handle(SearchJobPostsQuery request, CancellationToken cancellationToken)
        {
            var jobPosts = await _jobPostElasticService.SearchDataAsync(request.Query, cancellationToken);
            return _mapper.Map<List<JobPostResponseDto>>(jobPosts);
        }
    }
}