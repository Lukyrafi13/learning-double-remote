using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddColumnIsShowingInTableSectorLBU12And3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowing",
                table: "RfSectorLBU3s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowing",
                table: "RfSectorLBU2s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShowing",
                table: "RfSectorLBU1s",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowing",
                table: "RfSectorLBU3s");

            migrationBuilder.DropColumn(
                name: "IsShowing",
                table: "RfSectorLBU2s");

            migrationBuilder.DropColumn(
                name: "IsShowing",
                table: "RfSectorLBU1s");
        }
    }
}
