using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingAnalysisTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Startups",
                schema: "dbo",
                table: "Startups");

            migrationBuilder.RenameTable(
                name: "Startups",
                schema: "dbo",
                newName: "Startup",
                newSchema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Canton",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                schema: "dbo",
                table: "Startup",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoundedAt",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoundedYear",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FundingRoundsCount",
                schema: "dbo",
                table: "Startup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                schema: "dbo",
                table: "Startup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFundedAt",
                schema: "dbo",
                table: "Startup",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastValuation",
                schema: "dbo",
                table: "Startup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalFunding",
                schema: "dbo",
                table: "Startup",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasFunded",
                schema: "dbo",
                table: "Startup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Startup",
                schema: "dbo",
                table: "Startup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StartupFundingRound",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Investors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Valuation = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartupFundingRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StartupFundingRound_Startup_StartupId",
                        column: x => x.StartupId,
                        principalSchema: "dbo",
                        principalTable: "Startup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StartupFundingRound_StartupId",
                schema: "dbo",
                table: "StartupFundingRound",
                column: "StartupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartupFundingRound",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Startup",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Canton",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "FoundedAt",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "FoundedYear",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "FundingRoundsCount",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Industry",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "LastFundedAt",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "LastValuation",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "LegalName",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Region",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "Source",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "TotalFunding",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.DropColumn(
                name: "WasFunded",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.RenameTable(
                name: "Startup",
                schema: "dbo",
                newName: "Startups",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Startups",
                schema: "dbo",
                table: "Startups",
                column: "Id");
        }
    }
}
