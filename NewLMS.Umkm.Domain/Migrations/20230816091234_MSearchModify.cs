using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class MSearchModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MSearches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResultCondition",
                table: "MSearches",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultKey",
                table: "MSearches",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultSystem",
                table: "MSearches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VariableCondition",
                table: "MSearches",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VariableFields",
                table: "MSearches",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VariableSystem",
                table: "MSearches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "ResultCondition",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "ResultKey",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "ResultSystem",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "VariableCondition",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "VariableFields",
                table: "MSearches");

            migrationBuilder.DropColumn(
                name: "VariableSystem",
                table: "MSearches");
        }
    }
}
