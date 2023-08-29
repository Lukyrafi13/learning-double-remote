using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PersiapanAkadBiayaAsuransi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JenisCoverage",
                table: "PersiapanAkads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaBroker",
                table: "PersiapanAkads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PremiAsuransi",
                table: "PersiapanAkads",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JenisCoverage",
                table: "PersiapanAkads");

            migrationBuilder.DropColumn(
                name: "NamaBroker",
                table: "PersiapanAkads");

            migrationBuilder.DropColumn(
                name: "PremiAsuransi",
                table: "PersiapanAkads");
        }
    }
}
