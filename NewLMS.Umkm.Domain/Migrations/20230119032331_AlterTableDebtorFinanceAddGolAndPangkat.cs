using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableDebtorFinanceAddGolAndPangkat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DebtorFinance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gol",
                table: "DebtorFinance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pangkat",
                table: "DebtorFinance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "DebtorFinance",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DebtorFinance");

            migrationBuilder.DropColumn(
                name: "Gol",
                table: "DebtorFinance");

            migrationBuilder.DropColumn(
                name: "Pangkat",
                table: "DebtorFinance");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "DebtorFinance");
        }
    }
}
