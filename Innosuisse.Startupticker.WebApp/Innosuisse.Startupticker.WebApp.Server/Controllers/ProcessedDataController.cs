using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Innosuisse.Startupticker.WebApp.Server.DataBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public sealed class ProcessedDataController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProcessedDataController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("grid-data-startups")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoadResult))]
        public async Task<ActionResult> GetAll([FromBody] DataSourceLoadOptions loadOptions, CancellationToken cancellationToken)
        {
            var result = await DataSourceLoader.LoadAsync(dbContext.Startups.AsNoTracking().AsSplitQuery(), loadOptions, cancellationToken);
            return Ok(result);
        }

        [HttpGet("funding-round")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StartupFundingRound>))]
        public async Task<ActionResult> FundingRound([FromQuery] Guid startupId, CancellationToken cancellationToken)
        {
            var result = await dbContext.StartupsFundingRounds.Where(i => i.StartupId == startupId).ToListAsync(cancellationToken);
            return Ok(result);
        }
    }
}
