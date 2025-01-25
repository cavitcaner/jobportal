using JobPortal.Core.Events.JobEvents;
using JobPortal.JobPostingService.Application.CQRS.Commands.JobPost;
using JobPortal.JobPostingService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobPortal.JobPostingService.Application.Extensions
{
    public static class JobPostExtensions
    {
        public static CreateJobPostRequestDto ConvertToDto(this CreateJobPostCommand command)
        {
            return JsonSerializer.Deserialize<CreateJobPostRequestDto>(JsonSerializer.Serialize(command));
        }
    }
}
