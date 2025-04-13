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

        [HttpGet("chart-funding-by-year")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<object>))]
        public async Task<ActionResult> GetFundingByYear([FromQuery] int? fromYear, [FromQuery] int? toYear, CancellationToken cancellationToken)
        {
            var query = dbContext.StartupsFundingRounds
                .Where(r => r.Date != null && r.Amount != null);

            if (fromYear.HasValue)
                query = query.Where(r => r.Date!.Value.Year >= fromYear.Value);

            if (toYear.HasValue)
                query = query.Where(r => r.Date!.Value.Year <= toYear.Value);

            var result = await query
                .GroupBy(r => r.Date!.Value.Year)
                .Select(g => new
                {
                    Year = g.Key.ToString(),
                    TotalFunding = g.Sum(r => r.Amount)
                })
                .OrderBy(g => g.Year)
                .ToListAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("chart-funding-by-canton")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<object>))]
        public async Task<ActionResult> GetFundingByCanton([FromQuery] int? fromYear, [FromQuery] int? toYear, CancellationToken cancellationToken)
        {
            var query = dbContext.Startups
                .Where(s => s.Canton != null && s.TotalFunding != null);

            if (fromYear.HasValue)
                query = query.Where(s => s.FoundedYear >= fromYear.Value);

            if (toYear.HasValue)
                query = query.Where(s => s.FoundedYear <= toYear.Value);

            var result = await query
                .GroupBy(s => s.Canton!)
                .Select(g => new
                {
                    Canton = g.Key,
                    Funding = g.Sum(s => s.TotalFunding) ?? 0
                })
                .OrderByDescending(g => g.Funding)
                .ToListAsync(cancellationToken);

            return Ok(result);
        }

        [HttpGet("chart-startups-by-industry")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<object>))]
        public async Task<ActionResult> GetStartupsByIndustry([FromQuery] int? fromYear, [FromQuery] int? toYear, CancellationToken cancellationToken)
        {
            var query = dbContext.Startups
                .Where(s => s.FoundedYear != null && s.Industry != null);

            if (fromYear.HasValue)
                query = query.Where(s => s.FoundedYear >= fromYear.Value);

            if (toYear.HasValue)
                query = query.Where(s => s.FoundedYear <= toYear.Value);

            var result = await query
                .GroupBy(s => new { s.FoundedYear, s.Industry })
                .Select(g => new
                {
                    Year = g.Key.FoundedYear,
                    Industry = g.Key.Industry,
                    Count = g.Count()
                })
                .ToListAsync(cancellationToken);

            return Ok(result);
        }
    }
}
