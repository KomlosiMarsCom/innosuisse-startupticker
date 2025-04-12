using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Innosuisse.Startupticker.WebApp.Server.Utils;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    public sealed class SemanticSearchController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OpenAIService _openAIService;

        public SemanticSearchController(ApplicationDbContext dbContext, OpenAIService openAIService)
        {
            _dbContext = dbContext;
            _openAIService = openAIService;
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var queryEmbedding = await _openAIService.GetEmbeddingAsync(query);

            var companies = await _dbContext.Startups
                .Where(c => c.Embedding != null)
                .ToListAsync();

            var results = companies
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.CountryCode,
                    Similarity = VectorUtils.CosineSimilarity(queryEmbedding, c.Embedding!)
                })
                .OrderByDescending(r => r.Similarity)
                .Take(20);

            return Ok(results);
        }
    }
}
