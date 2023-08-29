using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppAgunanFurtherRefine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaDokumenAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanDokumenAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanDokumenAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoSuratUkurGambarSituasi",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiDokumenAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KabupatenKotaDokumenAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KecamatanDokumenAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KelurahanDokumenAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NoSuratUkurGambarSituasi",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PropinsiDokumenAgunan",
                table: "AppAgunans");
        }
    }
}
