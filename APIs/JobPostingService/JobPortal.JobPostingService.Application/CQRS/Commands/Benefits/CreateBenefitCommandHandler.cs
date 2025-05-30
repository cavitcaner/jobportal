using MediatR;
using JobPortal.JobPostingService.Domain.Entities;
using JobPortal.JobPostingService.Application.Interfaces;

namespace JobPortal.JobPostingService.Application.CQRS.Commands.Benefits
{
    public class CreateBenefitCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
    public class CreateBenefitCommandHandler : IRequestHandler<CreateBenefitCommand, Guid>
    {
        private readonly IBenefitService _benefitService;

        public CreateBenefitCommandHandler(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        public async Task<Guid> Handle(CreateBenefitCommand request, CancellationToken cancellationToken)
        {
            var benefit = new Benefit
            {
                Name = request.Name
            };

            await _benefitService.CreateBenefitAsync(benefit, cancellationToken);

            return benefit.Id;
        }
    }
}