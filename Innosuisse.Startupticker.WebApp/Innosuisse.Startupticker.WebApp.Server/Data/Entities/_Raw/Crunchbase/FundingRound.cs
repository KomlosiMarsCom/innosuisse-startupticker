namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase
{
    public sealed class FundingRound
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Permalink { get; set; }
        public required string CbUrl { get; set; }
        public required int Rank { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public string? CountryCode { get; set; }
        public string? StateCode { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? InvestmentType { get; set; }
        public DateTime? AnnouncedOn { get; set; }
        public decimal? RaisedAmountUsd { get; set; }
        public decimal? RaisedAmount { get; set; }
        public string? RaisedAmountCurrencyCode { get; set; }
        public decimal? PostMoneyValuationUsd { get; set; }
        public decimal? PostMoneyValuation { get; set; }
        public string? PostMoneyValuationCurrencyCode { get; set; }
        public int? InvestorCount { get; set; }
        public Guid? OrganizationId { get; set; }
        public string? OrgName { get; set; }
        public string? LeadInvestorUuids { get; set; }

        //nav
        public Organization? Organization { get; set; }
    }
}
