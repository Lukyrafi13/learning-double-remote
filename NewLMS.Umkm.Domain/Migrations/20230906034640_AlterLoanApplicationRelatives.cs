using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplicationRelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorEmergencyId",
                table: "LoanApplications",
                column: "DebtorEmergencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCompanyLegals_DebtorCompanies_Id",
                table: "DebtorCompanyLegals",
                column: "Id",
                principalTable: "DebtorCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DebtorEmergencies_DebtorEmergencyId",
                table: "LoanApplications",
                column: "DebtorEmergencyId",
                principalTable: "DebtorEmergencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCompanyLegals_DebtorCompanies_Id",
                table: "DebtorCompanyLegals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DebtorEmergencies_DebtorEmergencyId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DebtorEmergencyId",
                table: "LoanApplications");
        }
    }
}
