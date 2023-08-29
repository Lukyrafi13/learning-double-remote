using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaSelfFinancing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TPLCode",
                table: "RFInsCompanys");

            migrationBuilder.AddColumn<double>(
                name: "SelfFinancing",
                table: "AnalisaFasilitass",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelfFinancing",
                table: "AnalisaFasilitass");

            migrationBuilder.AddColumn<string>(
                name: "TPLCode",
                table: "RFInsCompanys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
