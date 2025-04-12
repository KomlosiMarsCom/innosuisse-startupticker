using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker;
using Microsoft.EntityFrameworkCore;

namespace Innosuisse.Startupticker.WebApp.Server.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Startup> Startups { get; set; } = null!;

        public required DbSet<Organization> Organizations { get; set; } = null!;

        public required DbSet<FundingRound> FundingRounds { get; set; } = null!;

        public required DbSet<Company> Companies { get; set; } = null!;

        public required DbSet<Deal> Deals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Startup>(m =>
            {
                m.HasKey(i => i.Id);
            });

            modelBuilder.Entity<Organization>(m =>
            {
                m.ToTable("_CrunchbaseOrganization");
                m.HasKey(i => i.Id);
            });

            modelBuilder.Entity<FundingRound>(m =>
            {
                m.ToTable("_CrunchbaseFundingRound");
                m.HasKey(i => i.Id);

                m.HasOne(o => o.Organization)
                    .WithMany()
                    .HasForeignKey(o => o.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Company>(m =>
            {
                m.ToTable("_StartuptickerCompany");
                m.HasKey(i => i.Title);
                m.Property(i => i.Title).HasMaxLength(300);
            });

            modelBuilder.Entity<Deal>(m =>
            {
                m.ToTable("_StartuptickerDeal");
                m.HasKey(i => i.Id);

                m.Property(i => i.Confidential).HasDefaultValue(false);
                m.Property(i => i.AmountConfidential).HasDefaultValue(false);
                m.HasOne(o => o.ECompany)
                    .WithMany()
                    .HasForeignKey(o => o.Company)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}