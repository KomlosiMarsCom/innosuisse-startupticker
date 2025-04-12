using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker;

namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class StartupFundingRound
    {
        public Guid Id { get; set; }
        public Guid StartupId { get; set; }
        public string? Investors { get; set; }
        public int? Amount { get; set; }
        public int? Valuation { get; set; }
        public DateTime? Date { get; set; }

        // nav props
        public Startup? Startup { get; set; }
    }
}
