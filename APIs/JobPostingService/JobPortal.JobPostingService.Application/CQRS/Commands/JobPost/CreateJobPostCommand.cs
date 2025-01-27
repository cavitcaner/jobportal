using AutoMapper;
using FluentValidation;
using JobPortal.Core.Helpers;
using JobPortal.Core.UnitOfWork;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Application.Interfaces.EventServices;
using JobPortal.JobPostingService.Domain.Entities;
using MediatR;
using Nest;

namespace JobPortal.JobPostingService.Application.CQRS.Commands.JobPost
{
    /// <summary>
    /// gönderilen bilgiler ile yeni bir ilan oluşturur
    /// </summary>
    public class CreateJobPostCommand :MediatR.IRequest<Guid>
    {
        public CreateJobPostRequestDto JobPost { get; set; }
    }

    public class CreateJobPostCommandHandler : IRequestHandler<CreateJobPostCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobPostElasticService _jobPostElasticService;
        private readonly IJobPostService _jobPostService;
        private readonly IEmployerEventService _employerEventService;

        public CreateJobPostCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJobPostService jobPostService,
            IJobPostElasticService jobPostElasticService,
            IEmployerEventService employerEventService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobPostService = jobPostService;
            _jobPostElasticService = jobPostElasticService;
            _employerEventService = employerEventService;
        }

        public async Task<Guid> Handle(CreateJobPostCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var limit = await _employerEventService.GetEmployerJobPostingLimit(request.JobPost.EmployerId);
                var totalPostsEmployer = await _jobPostElasticService.GetCountByEmployerIdAsync(request.JobPost.EmployerId, cancellationToken);
                ExceptionHelper.ThrowIf(limit == 0 || limit <= totalPostsEmployer, "İlan yayımlama hakkınız bulunmamaktadır.");

                var jobPost = _mapper.Map<Domain.Entities.JobPost>(request.JobPost);
                jobPost.ExpirationDate = DateTime.Now.AddDays(15);

                if (request.JobPost.Benefits?.Count > 0)
                {
                    jobPost.Benefits = request.JobPost.Benefits.Select(x => new Benefit() { Id = x }).ToList();
                }

                await _jobPostService.CreateJobPostAsync(jobPost, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var elasticModel = _mapper.Map<JobPostElasticModel>(jobPost);
                await _jobPostElasticService.IndexDataAsync(elasticModel, cancellationToken);
                await _unitOfWork.CommitAsync(cancellationToken);

                await _employerEventService.SendJobPostCreatedEventAsync(new Core.Events.JobEvents.JobPostCreatedEventRequest
                {
                    EmployerId = jobPost.EmployerId
                });

                return jobPost.Id;
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

        }
    }


    public class CreateJobPostCommandValidator : AbstractValidator<CreateJobPostCommand>
    {
        public CreateJobPostCommandValidator()
        {
            RuleFor(x => x.JobPost.Title)
                .NotEmpty().WithMessage("Başlık alanı boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık 100 karakterden uzun olamaz.");

            RuleFor(x => x.JobPost.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş olamaz.")
                .MaximumLength(2000).WithMessage("Açıklama 2000 karakterden uzun olamaz.");

            RuleFor(x => x.JobPost.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.JobPost.PositionId)
                .Must(x => x != Guid.Empty).WithMessage("Pozisyon bilgisi boş olamaz.");
        }
    }
}