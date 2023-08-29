using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppRedudansiCabang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KodeCabang",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaAO",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaCabang",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodeCabang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaAO",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaCabang",
                table: "Apps");
        }
    }
}
