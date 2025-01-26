//using JobPortal.Core.Repository;
//using JobPortal.Core.Statics;
//using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;
//using JobPortal.JobPostingService.Application.Interfaces;
//using Microsoft.Extensions.Hosting;
//using Nest;

//namespace JobPortal.JobPostingService.Infrastructure.EventHandlers
//{
//    public class JobPostCreatedEventHandler : BackgroundService
//    {
//        private readonly IJobPostElasticService _jobpostElasticService;
//        public JobPostCreatedEventHandler(IJobPostElasticService jobpostElasticService)
//        {
//            _jobpostElasticService = jobpostElasticService;
//        }

//        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
//        {
//            while (!cancellationToken.IsCancellationRequested)
//            {
//                //var message = await _messageBroker.ConsumeAsync();
//                //var data = JsonConvert.DeserializeObject<MyEntity>(message);
//                //await _elasticRepository.IndexAsync("my-index", data);

//                //await _jobpostElasticService.IndexDataAsync(new JobPostElasticModel
//                //{

//                //}, cancellationToken);
//            }
//        }

//        public override Task StopAsync(CancellationToken cancellationToken)
//        {
//            Console.WriteLine("JobPostCreatedEventHandler service is stopping...");
//            return base.StopAsync(cancellationToken);
//        }
//    }

//}
