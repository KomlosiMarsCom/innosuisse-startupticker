﻿// <auto-generated />
using System;
using Innosuisse.Startupticker.WebApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities.Startup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Startups", "dbo");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase.FundingRound", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AnnouncedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CbUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvestmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InvestorCount")
                        .HasColumnType("int");

                    b.Property<string>("LeadInvestorUuids")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrgName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PostMoneyValuation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PostMoneyValuationCurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PostMoneyValuationUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("RaisedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RaisedAmountCurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RaisedAmountUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("_CrunchbaseFundingRound", "dbo");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryGroupsList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CbUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FoundedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomepageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastFundingOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LegalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedinUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumExits")
                        .HasColumnType("int");

                    b.Property<int?>("NumFundingRounds")
                        .HasColumnType("int");

                    b.Property<string>("Permalink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalFunding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalFundingCurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalFundingUsd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("_CrunchbaseOrganization", "dbo");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker.Company", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Canton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Funded")
                        .HasColumnType("bit");

                    b.Property<string>("GenderCeo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Highlights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Oob")
                        .HasColumnType("bit");

                    b.Property<string>("SpinOffs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vertical")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("_StartuptickerCompany", "dbo");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker.Deal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("AmountConfidential")
                        .HasColumnType("bit");

                    b.Property<string>("Canton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Confidential")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfTheFundingRound")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenderCeo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Investors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Valuation")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.ToTable("_StartuptickerDeal", "dbo");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase.FundingRound", b =>
                {
                    b.HasOne("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Crunchbase.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker.Deal", b =>
                {
                    b.HasOne("Innosuisse.Startupticker.WebApp.Server.Data.Entities._Raw.Startupticker.Company", "ECompany")
                        .WithMany()
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ECompany");
                });
#pragma warning restore 612, 618
        }
    }
}
