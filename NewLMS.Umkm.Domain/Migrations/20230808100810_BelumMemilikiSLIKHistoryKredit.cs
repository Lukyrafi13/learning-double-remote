using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class BelumMemilikiSLIKHistoryKredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BelumMemilikiSLIK",
                table: "SlikRequestObjects");

            migrationBuilder.AddColumn<bool>(
                name: "BelumMemilikiSLIK",
                table: "SlikHistoryKredits",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BelumMemilikiSLIK",
                table: "SlikHistoryKredits");

            migrationBuilder.AddColumn<bool>(
                name: "BelumMemilikiSLIK",
                table: "SlikRequestObjects",
                type: "bit",
                nullable: true);
        }
    }
}
