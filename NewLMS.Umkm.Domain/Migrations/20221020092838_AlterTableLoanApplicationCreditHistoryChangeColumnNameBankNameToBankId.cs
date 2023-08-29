using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationCreditHistoryChangeColumnNameBankNameToBankId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfBanks_BankName",
                table: "LoanApplicationCreditHistories");

            migrationBuilder.RenameColumn(
                name: "BankName",
                table: "LoanApplicationCreditHistories",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplicationCreditHistories_BankName",
                table: "LoanApplicationCreditHistories",
                newName: "IX_LoanApplicationCreditHistories_BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfBanks_BankId",
                table: "LoanApplicationCreditHistories",
                column: "BankId",
                principalTable: "RfBanks",
                principalColumn: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfBanks_BankId",
                table: "LoanApplicationCreditHistories");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "LoanApplicationCreditHistories",
                newName: "BankName");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplicationCreditHistories_BankId",
                table: "LoanApplicationCreditHistories",
                newName: "IX_LoanApplicationCreditHistories_BankName");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditHistories_RfBanks_BankName",
                table: "LoanApplicationCreditHistories",
                column: "BankName",
                principalTable: "RfBanks",
                principalColumn: "BankId");
        }
    }
}
