using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker;

namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class Startup
    {
        public required Guid Id { get; set; }
        public required string Source { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public string? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? Canton { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? FoundedAt { get; set; }
        public string? FoundedYear { get; set; }

        public bool WasFunded { get; set; }
        public int? FundingRoundsCount { get; set; }
        public int? TotalFunding { get; set; }
        public int? LastValuation { get; set; }
        public DateTime? LastFundedAt { get; set; }
        
        public bool IsClosed { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
