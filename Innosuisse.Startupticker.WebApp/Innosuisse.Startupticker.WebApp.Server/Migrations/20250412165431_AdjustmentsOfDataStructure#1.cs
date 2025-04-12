using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentsOfDataStructure1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundedAt",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.RenameColumn(
                name: "LastFundedAt",
                schema: "dbo",
                table: "Startup",
                newName: "LastFundedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedOn",
                schema: "dbo",
                table: "Startup",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundedOn",
                schema: "dbo",
                table: "Startup");

            migrationBuilder.RenameColumn(
                name: "LastFundedOn",
                schema: "dbo",
                table: "Startup",
                newName: "LastFundedAt");

            migrationBuilder.AddColumn<string>(
                name: "FoundedAt",
                schema: "dbo",
                table: "Startup",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
