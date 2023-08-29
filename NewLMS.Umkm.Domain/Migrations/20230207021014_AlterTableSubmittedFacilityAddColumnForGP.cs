using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilityAddColumnForGP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GPInstallment",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInstallmentAfter",
                table: "SubmittedFacilitiesLogs",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterest",
                table: "SubmittedFacilitiesLogs",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterestSpread",
                table: "SubmittedFacilitiesLogs",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterestTotal",
                table: "SubmittedFacilitiesLogs",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPLoanTerm",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPRemainingInterest",
                table: "SubmittedFacilitiesLogs",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPInstallment",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInstallmentAfter",
                table: "SubmittedFacilities",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterest",
                table: "SubmittedFacilities",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterestSpread",
                table: "SubmittedFacilities",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPInterestTotal",
                table: "SubmittedFacilities",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GPLoanTerm",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GPRemainingInterest",
                table: "SubmittedFacilities",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPInstallment",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPInstallmentAfter",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPInterest",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPInterestSpread",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPInterestTotal",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPLoanTerm",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPRemainingInterest",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "GPInstallment",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPInstallmentAfter",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPInterest",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPInterestSpread",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPInterestTotal",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPLoanTerm",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "GPRemainingInterest",
                table: "SubmittedFacilities");
        }
    }
}
