using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Innosuisse.Startupticker.WebApp.Server.Utils;
using OpenAI.Chat;
using Innosuisse.Startupticker.WebApp.Server.Model;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    public sealed class ChatBotController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OpenAIService _openAIService;

        public ChatBotController(ApplicationDbContext dbContext, OpenAIService openAIService)
        {
            _dbContext = dbContext;
            _openAIService = openAIService;
        }

        [HttpPost("ask")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> AskAdvisor([FromBody] ChatBotMessage userMessage)
        {
            var systemPrompt = 
@"You are a helpful assistant. Answer the user's questions based on the information provided in the database. \
In the database are two sets of data:
1. Startup Ticker data about Swiss startups
2. Crunchbase data about worldwide startups
Please inform user that he can analyze those data via data grid and aggregation, charts and semantics / fulltext searches.";


            var reply = await _openAIService.GenerateChatResponseAsync(userMessage.SessionId, systemPrompt, userMessage.UserMessage, true);
            return Ok(reply);
        }
    }
}
