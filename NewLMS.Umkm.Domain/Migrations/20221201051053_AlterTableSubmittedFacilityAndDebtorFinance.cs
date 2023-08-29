using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilityAndDebtorFinance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OtherBankObligation",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemainingInBankBjb",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherBankObligation",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemainingInBankBjb",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "THT",
                table: "DebtorFinance",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherBankObligation",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "RemainingInBankBjb",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "OtherBankObligation",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "RemainingInBankBjb",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "THT",
                table: "DebtorFinance");
        }
    }
}
