using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innosuisse.Startupticker.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentsOfDataStructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"
ALTER TABLE [dbo].[_CrunchbaseOrganization] 
ADD YourColumnDecimal1 DECIMAL(18, 2)
ALTER TABLE [dbo].[_CrunchbaseOrganization] 
ADD YourColumnDecimal2 DECIMAL(18, 2)
GO

UPDATE [dbo].[_CrunchbaseOrganization]
SET YourColumnDecimal1 = TRY_CAST([TotalFundingUsd] AS DECIMAL(18, 2)), YourColumnDecimal2 = TRY_CAST([TotalFunding] AS DECIMAL(18, 2))
GO

ALTER TABLE [dbo].[_CrunchbaseOrganization] DROP COLUMN TotalFundingUsd
ALTER TABLE [dbo].[_CrunchbaseOrganization] DROP COLUMN TotalFunding


EXEC sp_rename '_CrunchbaseOrganization.YourColumnDecimal1', 'TotalFundingUsd', 'COLUMN';
EXEC sp_rename '_CrunchbaseOrganization.YourColumnDecimal2', 'TotalFunding', 'COLUMN';
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TotalFundingUsd",
                schema: "dbo",
                table: "_CrunchbaseOrganization",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TotalFunding",
                schema: "dbo",
                table: "_CrunchbaseOrganization",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
