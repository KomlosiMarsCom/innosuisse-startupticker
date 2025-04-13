using Innosuisse.Startupticker.WebApp.Server.Data;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Innosuisse.Startupticker.WebApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;

namespace Innosuisse.Startupticker.WebApp.Server.Controllers
{
    [ApiController]
    public sealed class DataFetchAndEnrichController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OpenAIService _openAIService;
        private const int _dataSetSize = 10;

        public DataFetchAndEnrichController(ApplicationDbContext dbContext, OpenAIService openAIService)
        {
            _dbContext = dbContext;
            _openAIService = openAIService;
        }

        [HttpPost("test-ai")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TestAi(CancellationToken cancellationToken)
        {
            //test
            return NoContent();
        }

        [HttpPost("sync-and-enrich-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> SyncAndEnrichData(CancellationToken cancellationToken)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM StartupFundingRound");
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM StartupTag");
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Startup");

            var startuptickerCompanies = await _dbContext.Companies
                .Where(i => i.Industry != "" && i.Industry != null)
                .Include(i => i.Deals)
                .AsNoTracking()
                .AsSplitQuery()
                .Take(_dataSetSize)
                .ToListAsync(cancellationToken);

            var crunchbaseOrganizations = await _dbContext.Organizations
                .Include(i => i.FundingRounds)
                .AsNoTracking()
                .AsSplitQuery()
                .Take(_dataSetSize)
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
                startup.Industry = startuptickerCompany.Industry;
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
                startup.Tags = new List<StartupTag>();

                // AI Embeddings
                startup.Embedding = await _openAIService.GetEmbeddingAsync(GetInputMessage(
                    $"Name: {startup.Name}", 
                    $"Industry: {startup.Industry}", 
                    $"CountryCode: {startup.CountryCode}"
                    //$"City: {startup.City}", 
                    //$"Canton: {startup.Canton}"
                ));

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

                // AI generated tags
                startup.Tags = (await GetTagsAsync(
                    $"Title: {startuptickerCompany.Title}",
                    $"Industry: {startuptickerCompany.Industry}"))
                    .Select(i => new StartupTag
                    {
                        StartupId = startup.Id,
                        Name = i
                    }).ToList();
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

                // AI categorization of industry
                startup.Industry = await GetIndustryAsync(
                    crunchbaseOrganization.Name, 
                    crunchbaseOrganization.ShortDescription, 
                    crunchbaseOrganization.CategoryList, 
                    crunchbaseOrganization.CategoryGroupsList);
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
                startup.Tags = new List<StartupTag>();

                // AI Embeddings
                startup.Embedding = await _openAIService.GetEmbeddingAsync(GetInputMessage(
                    $"Name: {startup.Name}", 
                    $"Industry: {startup.Industry}", 
                    $"CountryCode: {startup.CountryCode}"
                    //$"City: {startup.City}", 
                    //$"Region: {startup.Region}", 
                    //$"ShortDescription: {crunchbaseOrganization.ShortDescription}",
                    //$"CategoryList: {crunchbaseOrganization.CategoryList}",
                    //$"CategoryGroupsList: {crunchbaseOrganization.CategoryGroupsList}")
                ));

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

                // AI generated tags
                startup.Tags = (await GetTagsAsync(
                    $"Name: {crunchbaseOrganization.Name}",
                    $"ShortDescription: {crunchbaseOrganization.ShortDescription}",
                    $"CategoryList: {crunchbaseOrganization.CategoryList}",
                    $"CategoryGroupsList: {crunchbaseOrganization.CategoryGroupsList}"))
                    .Select(i => new StartupTag
                    {
                        StartupId = startup.Id,
                        Name = CapitalizeFirstLetter(i)
                    }).ToList();
            }
            await _dbContext.Startups.AddRangeAsync(newStartups);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private async Task<string> GetIndustryAsync(params string?[] inputs)
        {
            return await _openAIService.GenerateChatResponseAsync(Guid.NewGuid().ToString(),
                "Extract industry of company based on description and categories. Please choose just one word.",
                GetInputMessage(inputs),
                false
            );
        }

        private async Task<List<string>> GetTagsAsync(params string?[] inputs)
        {
            var result = await _openAIService.GenerateChatResponseAsync(Guid.NewGuid().ToString(),
                "Extract 3 to 5 relevant tags from this company with industry definition as comma separated list of tags.",
                GetInputMessage(inputs),
                false
            );

            return result.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private string GetInputMessage(params string?[] inputs)
        {
            return string.Join(" | ", inputs);
        }

        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
