using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class PKChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__StartuptickerDeal__StartuptickerCompany_Company",
                schema: "dbo",
                table: "_StartuptickerDeal");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StartuptickerCompany",
                schema: "dbo",
                table: "_StartuptickerCompany");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "nvarchar(300)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "_StartuptickerCompany",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "_StartuptickerCompany",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK__StartuptickerCompany",
                schema: "dbo",
                table: "_StartuptickerCompany",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK__StartuptickerDeal__StartuptickerCompany_Company",
                schema: "dbo",
                table: "_StartuptickerDeal",
                column: "Company",
                principalSchema: "dbo",
                principalTable: "_StartuptickerCompany",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__StartuptickerDeal__StartuptickerCompany_Company",
                schema: "dbo",
                table: "_StartuptickerDeal");

            migrationBuilder.DropPrimaryKey(
                name: "PK__StartuptickerCompany",
                schema: "dbo",
                table: "_StartuptickerCompany");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                schema: "dbo",
                table: "_StartuptickerDeal",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "_StartuptickerCompany",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "_StartuptickerCompany",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddPrimaryKey(
                name: "PK__StartuptickerCompany",
                schema: "dbo",
                table: "_StartuptickerCompany",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK__StartuptickerDeal__StartuptickerCompany_Company",
                schema: "dbo",
                table: "_StartuptickerDeal",
                column: "Company",
                principalSchema: "dbo",
                principalTable: "_StartuptickerCompany",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
