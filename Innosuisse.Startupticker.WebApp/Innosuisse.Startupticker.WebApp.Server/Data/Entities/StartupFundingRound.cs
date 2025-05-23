﻿using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker;

namespace Innosuisse.Startupticker.WebApp.Server.Data.Entities
{
    public sealed class StartupFundingRound
    {
        public Guid Id { get; set; }
        public required string DealId { get; set; }
        public Guid StartupId { get; set; }
        public string? Investors { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Valuation { get; set; }
        public DateTime? Date { get; set; }

        // nav props
        public Startup? Startup { get; set; }
    }
}
