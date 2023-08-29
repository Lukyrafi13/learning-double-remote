using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaCovenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BacaDanSetuju",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Covenant",
                table: "Analisas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BacaDanSetuju",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "Covenant",
                table: "Analisas");
        }
    }
}
