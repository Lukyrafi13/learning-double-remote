using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableFacilityRemoveColumnReferral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NikReference",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "NoBankAccountReference",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "NikReference",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "NoBankAccountReference",
                table: "SubmittedFacilities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NikReference",
                table: "SubmittedFacilitiesLogs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoBankAccountReference",
                table: "SubmittedFacilitiesLogs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NikReference",
                table: "SubmittedFacilities",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoBankAccountReference",
                table: "SubmittedFacilities",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);
        }
    }
}
