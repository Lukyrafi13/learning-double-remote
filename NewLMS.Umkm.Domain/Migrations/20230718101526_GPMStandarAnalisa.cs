using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class GPMStandarAnalisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FasilitasModalKerja",
                table: "AnalisaFasilitass",
                newName: "Fasilitas");

            migrationBuilder.AddColumn<double>(
                name: "GPMStandar",
                table: "Surveys",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPMStandar",
                table: "Surveys");

            migrationBuilder.RenameColumn(
                name: "Fasilitas",
                table: "AnalisaFasilitass",
                newName: "FasilitasModalKerja");
        }
    }
}
