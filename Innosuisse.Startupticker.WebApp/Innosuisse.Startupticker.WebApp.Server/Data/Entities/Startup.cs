namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class Startup
    {
        public required Guid Id { get; set; }
        public required string Source { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? LegalName { get; set; }
        public string? Industry { get; set; }
        public string? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? Canton { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public DateTime? FoundedOn { get; set; }
        public int? FoundedYear { get; set; }

        public bool WasFunded { get; set; }
        public decimal? FundingRoundsCount { get; set; }
        public decimal? TotalFunding { get; set; }
        public decimal? LastValuation { get; set; }
        public DateTime? LastFundedOn { get; set; }
        
        public bool IsClosed { get; set; }
        public DateTime? ClosedAt { get; set; }

        public float[]? Embedding { get; set; }

        // nav props
        public ICollection<StartupFundingRound>? StartupsFundingRounds { get; set; }
        public ICollection<StartupTag>? Tags { get; set; }
    }
}
