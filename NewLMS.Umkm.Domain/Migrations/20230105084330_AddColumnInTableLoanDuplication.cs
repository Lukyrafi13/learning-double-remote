using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnInTableLoanDuplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "LoanApplicationDuplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expired",
                table: "LoanApplicationDuplications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNo",
                table: "LoanApplicationDuplications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "LoanApplicationDuplications");

            migrationBuilder.DropColumn(
                name: "Expired",
                table: "LoanApplicationDuplications");

            migrationBuilder.DropColumn(
                name: "ReferenceNo",
                table: "LoanApplicationDuplications");
        }
    }
}
