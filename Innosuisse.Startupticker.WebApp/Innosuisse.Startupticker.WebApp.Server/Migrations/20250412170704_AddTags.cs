using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StartupTag",
                schema: "dbo",
                columns: table => new
                {
                    StartupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartupTag", x => new { x.StartupId, x.Name });
                    table.ForeignKey(
                        name: "FK_StartupTag_Startup_StartupId",
                        column: x => x.StartupId,
                        principalSchema: "dbo",
                        principalTable: "Startup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StartupTag",
                schema: "dbo");
        }
    }
}
