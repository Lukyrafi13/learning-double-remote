using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanAppCreditScoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoMonthlyMutationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoMonthlyMutationId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCreditScorings_ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings");

            migrationBuilder.DropColumn(
                name: "ScoMonthlyMutationId",
                table: "LoanApplicationCreditScorings");
        }
    }
}
