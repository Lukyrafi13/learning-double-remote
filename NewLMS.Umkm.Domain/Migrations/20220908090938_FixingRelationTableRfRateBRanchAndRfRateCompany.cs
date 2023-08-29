using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class FixingRelationTableRfRateBRanchAndRfRateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfRateBranches_RfBranches_BranchId",
                table: "RfRateBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateBranches_RfRates_RateId",
                table: "RfRateBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateCompanies_RfCompanies_CompanyId",
                table: "RfRateCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateCompanies_RfRates_RateId",
                table: "RfRateCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateBranches_RfBranches_BranchId",
                table: "RfRateBranches",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateBranches_RfRates_RateId",
                table: "RfRateBranches",
                column: "RateId",
                principalTable: "RfRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateCompanies_RfCompanies_CompanyId",
                table: "RfRateCompanies",
                column: "CompanyId",
                principalTable: "RfCompanies",
                principalColumn: "CompId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateCompanies_RfRates_RateId",
                table: "RfRateCompanies",
                column: "RateId",
                principalTable: "RfRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfRateBranches_RfBranches_BranchId",
                table: "RfRateBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateBranches_RfRates_RateId",
                table: "RfRateBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateCompanies_RfCompanies_CompanyId",
                table: "RfRateCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_RfRateCompanies_RfRates_RateId",
                table: "RfRateCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateBranches_RfBranches_BranchId",
                table: "RfRateBranches",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateBranches_RfRates_RateId",
                table: "RfRateBranches",
                column: "RateId",
                principalTable: "RfRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateCompanies_RfCompanies_CompanyId",
                table: "RfRateCompanies",
                column: "CompanyId",
                principalTable: "RfCompanies",
                principalColumn: "CompId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfRateCompanies_RfRates_RateId",
                table: "RfRateCompanies",
                column: "RateId",
                principalTable: "RfRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
