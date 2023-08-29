using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class TypoBRTFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BiayaRumahTanggaKeseluruhan20",
                table: "Surveys",
                newName: "BiayaRumahTanggaKeseluruhan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BiayaRumahTanggaKeseluruhan",
                table: "Surveys",
                newName: "BiayaRumahTanggaKeseluruhan20");
        }
    }
}
