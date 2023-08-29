using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSLIKRequestDebtorAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ByKesamaan",
                table: "SLIKRequestDebtors",
                type: "bit",
                defaultValue: true,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ByNoIdentitas",
                table: "SLIKRequestDebtors",
                type: "bit",
                defaultValue: true,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KodeRefPengguna",
                table: "SLIKRequestDebtors",
                type: "uniqueidentifier",
                defaultValueSql: "NEWID()",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TujuanPermintaan",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                defaultValue: "01",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ByKesamaan",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "ByNoIdentitas",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "KodeRefPengguna",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "TujuanPermintaan",
                table: "SLIKRequestDebtors");
        }
    }
}
