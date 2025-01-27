using MediatR;
using AutoMapper;
using JobPortal.JobPostingService.Application.Interfaces;
using JobPortal.JobPostingService.Application.DTOs;
using JobPortal.Core.Repository;

namespace JobPortal.JobPostingService.Application.CQRS.Queries.Benefits
{
    public class GetRequirementListQuery : IRequest<RequirementsDto>
    {
    }
    public class GetRequirementListQueryHandler : IRequestHandler<GetRequirementListQuery, RequirementsDto>
    {
        private readonly IGenericRepository<Domain.Entities.Benefit> _benefitRep;
        private readonly IGenericRepository<Domain.Entities.Position> _positionRep;
        private readonly IGenericRepository<Domain.Entities.WorkingMethod> _workingMethodRep;

        public GetRequirementListQueryHandler(IGenericRepository<Domain.Entities.Benefit> benefitRep, IGenericRepository<Domain.Entities.Position> positionRep, IGenericRepository<Domain.Entities.WorkingMethod> workingMethodRep)
        {
            _benefitRep = benefitRep;
            _positionRep = positionRep;
            _workingMethodRep = workingMethodRep;
        }

        public async Task<RequirementsDto> Handle(GetRequirementListQuery request, CancellationToken cancellationToken)
        {
            var benefits = await _benefitRep.GetAllAsync(cancellationToken);
            var positions = await _positionRep.GetAllAsync(cancellationToken);
            var workingMethods = await _workingMethodRep.GetAllAsync(cancellationToken);
            return new RequirementsDto
            {
                Benefits = benefits.Select(x => new ParameterDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Positions = positions.Select(x => new ParameterDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                WorkingMethods = workingMethods.Select(x => new ParameterDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
            };
        }
    }
}