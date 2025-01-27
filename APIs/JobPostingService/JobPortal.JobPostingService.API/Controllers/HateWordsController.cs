using JobPortal.JobPostingService.Infrastructure.Cache.MemoryCache;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.JobPostingService.API.Controllers
{
    [ApiController]
    [Route("api/hate-words")]
    public class HateWordsController : ControllerBase
    {
        private readonly HateWordsCacheService _hateWordsCacheService;

        public HateWordsController(HateWordsCacheService hateWordsCacheService)
        {
            _hateWordsCacheService = hateWordsCacheService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetHateWords()
        {
            var hateWords = await _hateWordsCacheService.GetListAsync();
            if (hateWords == null || !hateWords.Any())
                return NotFound("No hate words found in Redis.");

            return Ok(hateWords);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHateWords([FromBody] List<string> hateWords)
        {
            if (hateWords == null || !hateWords.Any())
                return BadRequest("Hate words list cannot be empty.");

            hateWords = hateWords
                .Select(w => w.Trim().ToLowerInvariant())
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Distinct()
                .ToList();

            await _hateWordsCacheService.SetAsync(hateWords, TimeSpan.FromDays(365));

            return Ok(new 
            { 
                Message = "Hate words successfully saved", 
                Count = hateWords.Count,
                Words = hateWords 
            });
        }
    }
} 