using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class FixingReferencesAndProspectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessStatus",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "TargetPladfond",
                table: "Prospects");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TargetPlafond",
                table: "Prospects",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "TargetPlafond",
                table: "Prospects");

            migrationBuilder.AddColumn<bool>(
                name: "ProcessStatus",
                table: "Prospects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TargetPladfond",
                table: "Prospects",
                type: "float",
                nullable: true);
        }
    }
}
