namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker
{
    public sealed class Deal
    {
        public required string Id { get; set; }
        public string? Investors { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Valuation { get; set; }
        public string? Comment { get; set; }
        public string? Url { get; set; }
        public bool Confidential { get; set; }
        public bool AmountConfidential { get; set; }
        public DateTime? DateOfTheFundingRound { get; set; }
        public string? Type { get; set; }
        public string? Phase { get; set; }
        public string? Canton { get; set; }
        public string? Company { get; set; }
        public string? GenderCeo { get; set; }

        //nav
        public Company? ECompany { get; set; }
    }
}
