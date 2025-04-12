using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitRawTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "_CrunchbaseOrganization",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CbUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomepageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryGroupsList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumFundingRounds = table.Column<int>(type: "int", nullable: true),
                    TotalFundingUsd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFunding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalFundingCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoundedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFundingOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumExits = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CrunchbaseOrganization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_StartuptickerCompany",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vertical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpinOffs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderCeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oob = table.Column<bool>(type: "bit", nullable: false),
                    Funded = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StartuptickerCompany", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Startups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Startups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_CrunchbaseFundingRound",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permalink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CbUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnouncedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RaisedAmountUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RaisedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RaisedAmountCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostMoneyValuationUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PostMoneyValuation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PostMoneyValuationCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestorCount = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadInvestorUuids = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CrunchbaseFundingRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CrunchbaseFundingRound__CrunchbaseOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "dbo",
                        principalTable: "_CrunchbaseOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_StartuptickerDeal",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Investors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Valuation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confidential = table.Column<bool>(type: "bit", nullable: false),
                    AmountConfidential = table.Column<bool>(type: "bit", nullable: false),
                    DateOfTheFundingRound = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GenderCeo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StartuptickerDeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK__StartuptickerDeal__StartuptickerCompany_Company",
                        column: x => x.Company,
                        principalSchema: "dbo",
                        principalTable: "_StartuptickerCompany",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX__CrunchbaseFundingRound_OrganizationId",
                schema: "dbo",
                table: "_CrunchbaseFundingRound",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX__StartuptickerDeal_Company",
                schema: "dbo",
                table: "_StartuptickerDeal",
                column: "Company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_CrunchbaseFundingRound",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "_StartuptickerDeal",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Startups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "_CrunchbaseOrganization",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "_StartuptickerCompany",
                schema: "dbo");
        }
    }
}
