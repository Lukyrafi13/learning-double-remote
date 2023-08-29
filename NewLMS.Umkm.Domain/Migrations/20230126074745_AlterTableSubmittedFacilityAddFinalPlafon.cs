using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilityAddFinalPlafon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FinalPlafond",
                table: "SubmittedFacilitiesLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FinalPlafond",
                table: "SubmittedFacilities",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPlafond",
                table: "SubmittedFacilitiesLogs");

            migrationBuilder.DropColumn(
                name: "FinalPlafond",
                table: "SubmittedFacilities");
        }
    }
}
