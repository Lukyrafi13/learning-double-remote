using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddColumnCodeForEachTableRfParamScoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringStatusCredits",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringServicePeriods",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringResidenceStatuses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringNumberOfDepents",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringMaritalStatuses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringEmployeeStatuses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringDebtorTypes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringCreditTerms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RFScoringBICheckings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RfScoringAgings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringStatusCredits");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringServicePeriods");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringResidenceStatuses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringNumberOfDepents");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringMaritalStatuses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringEmployeeStatuses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringDebtorTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringCreditTerms");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RFScoringBICheckings");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RfScoringAgings");
        }
    }
}
