using Innosuisse.Startupticker.WebApp.Server.Data.Entities;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase;
using Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        public required DbSet<StartupFundingRound> StartupsFundingRounds { get; set; } = null!;


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
                    .WithMany(i => i.FundingRounds)
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
                    .WithMany(i => i.Deals)
                    .HasForeignKey(o => o.Company)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Startup>(m =>
            {
                m.ToTable("Startup");
                m.HasKey(i => i.Id);

                m.Property(c => c.Embedding)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), // Serialize float[] to JSON
                        v => JsonSerializer.Deserialize<float[]>(v, (JsonSerializerOptions?)null)! // Deserialize JSON to float[]
                    )
                    .HasColumnType("nvarchar(max)"); // Use nvarchar(max) to store JSON in SQL Server
            });

            modelBuilder.Entity<StartupFundingRound>(m =>
            {
                m.ToTable("StartupFundingRound");
                m.HasKey(i => i.Id);

                m.HasOne(o => o.Startup)
                   .WithMany(i => i.StartupsFundingRounds)
                   .IsRequired()
                   .HasForeignKey(o => o.StartupId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StartupTag>(m =>
            {
                m.ToTable("StartupTag");
                m.HasKey(i => new { i.StartupId, i.Name });

                m.HasOne(o => o.Startup)
                   .WithMany(i => i.Tags)
                   .IsRequired()
                   .HasForeignKey(o => o.StartupId)
                   .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}