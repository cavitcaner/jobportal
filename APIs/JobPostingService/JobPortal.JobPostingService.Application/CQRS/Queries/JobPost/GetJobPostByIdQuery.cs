using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Nest;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.Interfaces;

namespace JobPortal.JobPostingService.Application.CQRS.Queries.JobPost
{
    /// <summary>
    /// ilan idsi ile henüz süresi dolmamýþ olan ilaný döner
    /// </summary>
    public class GetJobPostByIdQuery : MediatR.IRequest<JobPostResponseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetJobPostByIdQueryHandler : IRequestHandler<GetJobPostByIdQuery, JobPostResponseDto>
    {
        private readonly IJobPostElasticService _jobPostElasticService;
        private readonly IMapper _mapper;

        public GetJobPostByIdQueryHandler(IMapper mapper, IJobPostElasticService jobPostElasticService)
        {
            _mapper = mapper;
            _jobPostElasticService = jobPostElasticService;
        }

        public async Task<JobPostResponseDto> Handle(GetJobPostByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobPostElasticService.GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<JobPostResponseDto>(result);
        }
    }
}