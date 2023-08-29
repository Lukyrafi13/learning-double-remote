using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class UpdateTableLoanApplicationAddColumnBranchAndSubSector3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "LoanApplications",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RfSectorLBU3Code",
                table: "LoanApplications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BranchId",
                table: "LoanApplications",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfSectorLBU3Code",
                table: "LoanApplications",
                column: "RfSectorLBU3Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_BranchId",
                table: "LoanApplications",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfSectorLBU3s_RfSectorLBU3Code",
                table: "LoanApplications",
                column: "RfSectorLBU3Code",
                principalTable: "RfSectorLBU3s",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_BranchId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfSectorLBU3s_RfSectorLBU3Code",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BranchId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_RfSectorLBU3Code",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfSectorLBU3Code",
                table: "LoanApplications");
        }
    }
}
