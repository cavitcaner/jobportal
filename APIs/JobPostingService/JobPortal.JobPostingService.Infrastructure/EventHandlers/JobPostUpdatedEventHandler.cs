using JobPortal.Core.Repository;
using JobPortal.Core.Statics;
using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
using Microsoft.Extensions.Hosting;
using Nest;

namespace JobPortal.JobPostingService.Infrastructure.EventHandlers
{
    public class JobPostUpdatedEventHandler : BackgroundService
    {
        private readonly IElasticClient _elasticClient;
        public JobPostUpdatedEventHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                //var message = await _messageBroker.ConsumeAsync();
                //var data = JsonConvert.DeserializeObject<MyEntity>(message);
                //await _elasticRepository.IndexAsync("my-index", data);


                //await _jobPostService.UpdateJobPostAsync(jobPost, cancellationToken);

                //var position = await _positionRepository.GetByIdAsync(request.PositionId, cancellationToken);
                //var workingMethod = await _workingMethodRepository.GetByIdAsync(request.WorkingMethodId, cancellationToken);
                //var benefits = await _benefitRepository.GetByIdsAsync(request.Benefits, cancellationToken);

                //var elasticJobPost = await _elasticClient.GetByIdAsync(request.Id);
                //elasticJobPost.Title = request.Title;
                //elasticJobPost.Description = request.Description;
                //elasticJobPost.Salary = request.Salary;
                //elasticJobPost.Position = position?.Name;
                //elasticJobPost.WorkingMethod = workingMethod?.Name;
                //elasticJobPost.Benefits = benefits?.Select(x => x.Name).ToList();
                //await _elasticClient.UpdateAsync(elasticJobPost);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("JobPostCreatedEventHandler service is stopping...");
            return base.StopAsync(cancellationToken);
        }
    }

}
