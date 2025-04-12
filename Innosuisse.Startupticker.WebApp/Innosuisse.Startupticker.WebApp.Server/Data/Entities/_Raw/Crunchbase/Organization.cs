namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase
{
    public sealed class Organization
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Permalink { get; set; }
        public required string CbUrl { get; set; }
        public required int Rank { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public string? LegalName { get; set; }
        public required string Roles { get; set; }
        public string? Domain { get; set; }
        public string? HomepageUrl { get; set; }
        public string? CountryCode { get; set; }
        public string? StateCode { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Status { get; set; }
        public string? ShortDescription { get; set; }
        public string? CategoryList { get; set; }
        public string? CategoryGroupsList { get; set; }
        public int? NumFundingRounds { get; set; }
        public string? TotalFundingUsd { get; set; }
        public string? TotalFunding { get; set; }
        public string? TotalFundingCurrencyCode { get; set; }
        public DateTime? FoundedOn { get; set; }
        public DateTime? LastFundingOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string? EmployeeCount { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? LogoUrl { get; set; }
        public string? Alias1 { get; set; }
        public string? Alias2 { get; set; }
        public string? Alias3 { get; set; }
        public string? PrimaryRole { get; set; }
        public int? NumExits { get; set; }
    }
}
