namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker
{
    public sealed class Company
    {
        public required string Code { get; set; }
        public required string Title { get; set; }
        public string? Industry { get; set; }
        public string? Vertical { get; set; }
        public string? Canton { get; set; }
        public string? SpinOffs { get; set; }
        public string? City { get; set; }
        public int Year { get; set; }
        public string? Highlights { get; set; }
        public string? GenderCeo { get; set; }
        public bool Oob { get; set; }
        public bool Funded { get; set; }
        public string? Comment { get; set; }
    }
}
