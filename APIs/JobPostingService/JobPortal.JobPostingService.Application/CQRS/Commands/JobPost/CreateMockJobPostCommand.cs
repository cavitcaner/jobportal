using AutoMapper;
using Bogus;
using JobPortal.Core.Repository;
using JobPortal.Core.UnitOfWork;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Domain.Entities;
using MediatR;
using Nest;
using System.Net.Sockets;

namespace JobPortal.JobPostingService.Application.CQRS.Commands.JobPost
{
    /// <summary>
    /// belirtilen miktar kadar mock data oluşturur
    /// </summary>
    public class CreateMockJobPostCommand : MediatR.IRequest
    {
        public int Amount { get; set; }
    }

    public class CreateMockJobPostCommandHandler : IRequestHandler<CreateMockJobPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobPostElasticService _jobPostElasticService;
        private readonly IJobPostService _jobPostService;
        private readonly IGenericRepository<WorkingMethod> _workingMethodRep;
        private readonly IGenericRepository<Position> _positionRep;
        private readonly IGenericRepository<Benefit> _benefitRep;

        public CreateMockJobPostCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IJobPostService jobPostService,
            IJobPostElasticService jobPostElasticService,
            IGenericRepository<WorkingMethod> workingMethodRep,
            IGenericRepository<Position> positionRep,
            IGenericRepository<Benefit> benefitRep)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobPostService = jobPostService;
            _jobPostElasticService = jobPostElasticService;
            _workingMethodRep = workingMethodRep;
            _positionRep = positionRep;
            _benefitRep = benefitRep;
        }

        public async Task Handle(CreateMockJobPostCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                //var employers = await _messageBus.GetEmployers();
                var workingMethods = await _workingMethodRep.GetAllAsync(cancellationToken);
                var positions = await _positionRep.GetAllAsync(cancellationToken);
                var benefits = await _benefitRep.GetAllAsync(cancellationToken);

                ICollection<Benefit> TakeSomeBenefits(int amount)
                {
                    return benefits.OrderBy(x => amount).Take(amount).ToList();
                }

                var sirketFaker = new Faker<Domain.Entities.JobPost>("tr")
                    .RuleFor(s => s.CompanyName, f => f.Company.CompanyName())
                    .RuleFor(s => s.Title, f => f.Commerce.ProductName())
                    .RuleFor(s => s.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(s => s.Location, f => f.Address.State() + ", " + f.Address.City())
                    .RuleFor(s => s.Requirements, f => f.Rant.Review())
                    .RuleFor(s => s.Salary, f => decimal.Parse(f.Commerce.Price(49500, 150000)))
                    .RuleFor(s => s.WorkingMethodId, f => workingMethods.ElementAt(f.Random.Int(0, workingMethods.Count - 1)).Id)
                    .RuleFor(s => s.PositionId, f => positions.ElementAt(f.Random.Int(0, positions.Count - 1)).Id)
                    .RuleFor(s => s.Benefits, f => TakeSomeBenefits(f.Random.Int(0, benefits.Count)));

                var jobPosts = sirketFaker.Generate(request.Amount);

                foreach (var jobPost in jobPosts)
                {
                    jobPost.ExpirationDate = DateTime.Now.AddDays(15);

                    await _jobPostService.CreateJobPostAsync(jobPost, cancellationToken);
                    jobPost.WorkingMethod = workingMethods.FirstOrDefault(x => x.Id == jobPost.WorkingMethodId);
                    jobPost.Position = positions.FirstOrDefault(x => x.Id == jobPost.PositionId);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    var elasticModel = _mapper.Map<JobPostElasticModel>(jobPost);
                    await _jobPostElasticService.IndexDataAsync(elasticModel, cancellationToken);
                }

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}