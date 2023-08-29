using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class UpdateTableSubmittedFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministrationFee",
                table: "SubmittedFacilitiesLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdministrationFee",
                table: "SubmittedFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChargeCodeFeeAdministration",
                table: "RfSubProducts",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrationFee",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "AdministrationFee",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "ChargeCodeFeeAdministration",
                table: "RfSubProducts");
        }
    }
}
