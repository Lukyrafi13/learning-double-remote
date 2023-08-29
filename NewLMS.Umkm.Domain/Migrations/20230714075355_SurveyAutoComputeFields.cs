using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SurveyAutoComputeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiayaRumahTanggaKeseluruhan",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "BiayaRumahTanggaTertinggi",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "GPMTerendah",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "HPP",
                table: "Surveys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BiayaRumahTanggaKeseluruhan",
                table: "Surveys",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BiayaRumahTanggaTertinggi",
                table: "Surveys",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GPMTerendah",
                table: "Surveys",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPP",
                table: "Surveys",
                type: "float",
                nullable: true);
        }
    }
}
