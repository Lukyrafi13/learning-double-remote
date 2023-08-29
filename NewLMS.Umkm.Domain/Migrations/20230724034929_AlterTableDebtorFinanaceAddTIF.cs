using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableDebtorFinanaceAddTIF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InterestType",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MGEstimatedRetirementBenefit",
                table: "DebtorFinance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TIF",
                table: "DebtorFinance",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestType",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "MGEstimatedRetirementBenefit",
                table: "DebtorFinance");

            migrationBuilder.DropColumn(
                name: "TIF",
                table: "DebtorFinance");
        }
    }
}
