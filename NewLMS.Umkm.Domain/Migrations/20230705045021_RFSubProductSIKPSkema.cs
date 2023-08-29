using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFSubProductSIKPSkema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SIKPParentSkema",
                table: "RFSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SIKPSkema",
                table: "RFSubProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SIKPParentSkema",
                table: "RFSubProducts");

            migrationBuilder.DropColumn(
                name: "SIKPSkema",
                table: "RFSubProducts");
        }
    }
}
