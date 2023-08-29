using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaRemoveSBDKField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SBDKKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKKorporasi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKMikro",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKNonKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKRitel",
                table: "Analisas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SBDKKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKKorporasi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKMikro",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKNonKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKRitel",
                table: "Analisas",
                type: "float",
                nullable: true);
        }
    }
}
