using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    public sealed class DataFetchAndEnrichController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DataFetchAndEnrichController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost("sync-and-enrich-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> SyncAndEnrichData(CancellationToken cancellationToken)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM StartupFundingRound");
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Startup");

            var startuptickerCompanies = await _dbContext.Companies
                .Include(i => i.Deals)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync(cancellationToken);

            var startuptickerDeals = await _dbContext.Deals
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var crunchbaseOrganizations = await _dbContext.Organizations
                .Include(i => i.FundingRounds)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync(cancellationToken);

            var crunchbaseFundingRounds = await _dbContext.FundingRounds
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var newStartups = new List<Startup>();
            foreach (var startuptickerCompany in startuptickerCompanies)
            {
                var startup = new Startup
                {
                    Id = Guid.NewGuid(),
                    Source = "StartupTicker",
                    Name = startuptickerCompany.Title,
                };
                newStartups.Add(startup);

                startup.Description = null;
                startup.LegalName = startuptickerCompany.Title;
                startup.Industry = startuptickerCompany.Industry; // + TODO
                startup.CountryCode = "CHE";
                startup.Country = "Switzerland";
                startup.Canton = startuptickerCompany.Canton;
                startup.Region = null;
                startup.City = startuptickerCompany.City;
                startup.FoundedOn = null;
                startup.FoundedYear = startuptickerCompany.Year;
                startup.WasFunded = startuptickerCompany.Funded;
                startup.FundingRoundsCount = startuptickerCompany.Deals?.Count() ?? 0;
                startup.TotalFunding = startuptickerCompany.Deals?.Sum(i => i.Amount) ?? 0;
                startup.LastValuation = startuptickerCompany.Deals?.OrderByDescending(i => i.DateOfTheFundingRound).FirstOrDefault()?.Valuation;
                startup.LastFundedOn = startuptickerCompany.Deals?.OrderByDescending(i => i.DateOfTheFundingRound).FirstOrDefault()?.DateOfTheFundingRound;
                startup.IsClosed = startuptickerCompany.Oob;
                startup.ClosedAt = null;
                startup.StartupsFundingRounds = new List<StartupFundingRound>();

                if (startuptickerCompany.Deals != null)
                {
                    foreach (var deal in startuptickerCompany.Deals)
                    {
                        var startupFundingRound = new StartupFundingRound
                        {
                            Id = Guid.NewGuid(),
                            DealId = deal.Id,
                            StartupId = startup.Id,
                            Investors = deal.Investors,
                            Amount = deal.Amount,
                            Valuation = deal.Valuation,
                            Date = deal.DateOfTheFundingRound
                        };
                        startup.StartupsFundingRounds.Add(startupFundingRound);
                    }
                }
            }
            
            foreach (var crunchbaseOrganization in crunchbaseOrganizations)
            {
                var startup = new Startup
                {
                    Id = Guid.NewGuid(),
                    Source = "Crunchbase",
                    Name = crunchbaseOrganization.Name,
                };
                newStartups.Add(startup);

                startup.Description = null;
                startup.LegalName = crunchbaseOrganization.Name;
                startup.Industry = null; // TODO 
                startup.CountryCode = crunchbaseOrganization.CountryCode;
                startup.Country = null;
                startup.Canton = null;
                startup.Region = null;
                startup.City = crunchbaseOrganization.City;
                startup.FoundedOn = crunchbaseOrganization.FoundedOn;
                startup.FoundedYear = crunchbaseOrganization.FoundedOn?.Year;
                startup.WasFunded = crunchbaseOrganization.FundingRounds?.Count() > 0;
                startup.FundingRoundsCount = crunchbaseOrganization.FundingRounds?.Count();
                startup.TotalFunding = crunchbaseOrganization.TotalFundingUsd;
                startup.LastValuation = crunchbaseOrganization.FundingRounds?.OrderByDescending(i => i.CreatedAt).FirstOrDefault()?.PostMoneyValuationUsd;
                startup.LastFundedOn = crunchbaseOrganization.LastFundingOn;
                startup.IsClosed = crunchbaseOrganization.ClosedOn.HasValue;
                startup.ClosedAt = crunchbaseOrganization.ClosedOn;
                startup.StartupsFundingRounds = new List<StartupFundingRound>();

                if (crunchbaseOrganization.FundingRounds != null)
                {
                    foreach (var fundingRound in crunchbaseOrganization.FundingRounds)
                    {
                        var startupFundingRound = new StartupFundingRound
                        {
                            Id = Guid.NewGuid(),
                            DealId = fundingRound.Id.ToString(),
                            StartupId = startup.Id,
                            Investors = fundingRound.LeadInvestorUuids, // we have just IDs
                            Amount = fundingRound.RaisedAmountUsd,
                            Valuation = fundingRound.PostMoneyValuationUsd,
                            Date = fundingRound.AnnouncedOn
                        };
                        startup.StartupsFundingRounds.Add(startupFundingRound);
                    }
                }
            }
            await _dbContext.Startups.AddRangeAsync(newStartups);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
