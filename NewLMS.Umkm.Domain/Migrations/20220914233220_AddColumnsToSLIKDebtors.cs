using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddColumnsToSLIKDebtors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "SLIKRequestDebtors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SIDStatus",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SLIKDocumentUrl",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "SIDStatus",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "SLIKDocumentUrl",
                table: "SLIKRequestDebtors");
        }
    }
}
