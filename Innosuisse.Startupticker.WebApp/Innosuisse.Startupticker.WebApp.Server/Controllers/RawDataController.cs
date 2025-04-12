using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.DataBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    public sealed class RawDataController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public RawDataController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("grid-data-startupticker")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoadResult))]
        public async Task<ActionResult> GetAllStartupticker([FromBody] DataSourceLoadOptions loadOptions, CancellationToken cancellationToken)
        {
            var result = await DataSourceLoader.LoadAsync(dbContext.Companies.Include(i => i.Deals).AsNoTracking().AsSplitQuery(), loadOptions, cancellationToken);
            return Ok(result);
        }

        [HttpPost("grid-data-crunchbase")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoadResult))]
        public async Task<ActionResult> GetAllCrunchbase([FromBody] DataSourceLoadOptions loadOptions, CancellationToken cancellationToken)
        {
            var result = await DataSourceLoader.LoadAsync(dbContext.Organizations.Include(i => i.FundingRounds).AsNoTracking().AsSplitQuery(), loadOptions, cancellationToken);
            return Ok(result);
        }
    }
}
