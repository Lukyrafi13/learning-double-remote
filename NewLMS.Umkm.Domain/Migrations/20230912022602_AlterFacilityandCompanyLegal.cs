using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterFacilityandCompanyLegal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanTerm",
                table: "LoanApplicationFacilities");

            migrationBuilder.AddColumn<string>(
                name: "TenorCode",
                table: "LoanApplicationFacilities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SKDate",
                table: "DebtorCompanyLegals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_TenorCode",
                table: "LoanApplicationFacilities",
                column: "TenorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationFacilities_RfTenors_TenorCode",
                table: "LoanApplicationFacilities",
                column: "TenorCode",
                principalTable: "RfTenors",
                principalColumn: "TenorCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationFacilities_RfTenors_TenorCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationFacilities_TenorCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropColumn(
                name: "TenorCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropColumn(
                name: "SKDate",
                table: "DebtorCompanyLegals");

            migrationBuilder.AddColumn<int>(
                name: "LoanTerm",
                table: "LoanApplicationFacilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
