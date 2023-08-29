using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDupSearchRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResultType",
                table: "PrescreeningDuplikasis",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchDesc",
                table: "PrescreeningDuplikasis",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchId",
                table: "PrescreeningDuplikasis",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchType",
                table: "PrescreeningDuplikasis",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "PrescreeningDuplikasis",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultType",
                table: "PrescreeningDuplikasis");

            migrationBuilder.DropColumn(
                name: "SearchDesc",
                table: "PrescreeningDuplikasis");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "PrescreeningDuplikasis");

            migrationBuilder.DropColumn(
                name: "SearchType",
                table: "PrescreeningDuplikasis");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "PrescreeningDuplikasis");
        }
    }
}
