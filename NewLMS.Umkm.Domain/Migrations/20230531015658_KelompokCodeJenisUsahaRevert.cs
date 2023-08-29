using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class KelompokCodeJenisUsahaRevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KELOMPOK_CODE",
                table: "RFJenisUsahas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KELOMPOK_CODE",
                table: "RFJenisUsahas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
