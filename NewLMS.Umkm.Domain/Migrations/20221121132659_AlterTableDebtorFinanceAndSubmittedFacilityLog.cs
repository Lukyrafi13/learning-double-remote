using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDebtorFinanceAndSubmittedFacilityLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TargetPlafond",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccupationDesc",
                table: "DebtorFinance",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetPlafond",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "OccupationDesc",
                table: "DebtorFinance");
        }
    }
}
