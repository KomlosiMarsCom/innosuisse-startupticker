using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Confidential",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "AmountConfidential",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Confidential",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "AmountConfidential",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
