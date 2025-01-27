using AutoMapper;
using FluentValidation;
using JobPortal.Core.Events.EmployerEvents;
using JobPortal.Core.Helpers;
using JobPortal.Core.Repository;
using JobPortal.Core.UnitOfWork;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Application.Interfaces.EventServices;
using JobPortal.JobPostingService.Domain.Entities;
using MediatR;
using Nest;
using System.Collections.Generic;

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
        private readonly IGenericRepository<Benefit> _benefitRepository;
        private readonly IGenericRepository<WorkingMethod> _wmRepository;
        private readonly IGenericRepository<Position> _positionRepository;

        public CreateJobPostCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJobPostService jobPostService,
            IJobPostElasticService jobPostElasticService,
            IEmployerEventService employerEventService
,
            IGenericRepository<Benefit> benefitRepository,
            IGenericRepository<WorkingMethod> wmRepository,
            IGenericRepository<Position> positionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobPostService = jobPostService;
            _jobPostElasticService = jobPostElasticService;
            _employerEventService = employerEventService;
            _benefitRepository = benefitRepository;
            _wmRepository = wmRepository;
            _positionRepository = positionRepository;
        }

        public async Task<Guid> Handle(CreateJobPostCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                var response = await _employerEventService.GetEmployerJobPostingLimit(request.JobPost.EmployerId);
                ExceptionHelper.ThrowIf(response == null, "işveren bulunamadı!");

                var totalPostsEmployer = await _jobPostElasticService.GetCountByEmployerIdAsync(request.JobPost.EmployerId, cancellationToken);
                ExceptionHelper.ThrowIf(response.LimitOfJobPosting == 0 || response.LimitOfJobPosting <= totalPostsEmployer, "İlan yayımlama hakkınız bulunmamaktadır.");
                Domain.Entities.JobPost jobPost = await PrepareModel(request, response, cancellationToken);
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
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

        }

        private async Task<Domain.Entities.JobPost> PrepareModel(CreateJobPostCommand request, GetEmployerJobPostingLimitEventResponse? response, CancellationToken cancellationToken)
        {
            var jobPost = _mapper.Map<Domain.Entities.JobPost>(request.JobPost);
            jobPost.ExpirationDate = DateTime.Now.AddDays(15);
            jobPost.CompanyName = response.CompanyName;

            if (request.JobPost.Benefits?.Count > 0)
            {
                var benefits = await _benefitRepository.GetAllAsync(cancellationToken);
                jobPost.Benefits = benefits.Where(x => request.JobPost.Benefits.Contains(x.Id)).ToList();
            }

            if (request.JobPost.WorkingMethodId != Guid.Empty)
            {
                jobPost.WorkingMethod = await _wmRepository.GetByIdAsync(request.JobPost.WorkingMethodId.Value, cancellationToken);
                ExceptionHelper.ThrowIfNullOrEmpty(jobPost.WorkingMethod, "Çalışma Tipi Bulunamadı.");
            }

            if (request.JobPost.PositionId != Guid.Empty)
            {
                jobPost.Position = await _positionRepository.GetByIdAsync(request.JobPost.PositionId, cancellationToken);
                ExceptionHelper.ThrowIfNullOrEmpty(jobPost.Position, "Pozisyon Bulunamadı.");
            }

            return jobPost;
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

            RuleFor(x => x.JobPost.PositionId)
                .Must(x => x != Guid.Empty).WithMessage("Pozisyon bilgisi boş olamaz.");
        }
    }
}