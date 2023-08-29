using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableProspectAndCreditContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Prospects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AnswerOOK",
                table: "LoanApplicationCreditContractTerms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdOOK",
                table: "LoanApplicationCreditContractTerms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditContractTerms_UserIdOOK",
                table: "LoanApplicationCreditContractTerms",
                column: "UserIdOOK");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCreditContractTerms_SCUsers_UserIdOOK",
                table: "LoanApplicationCreditContractTerms",
                column: "UserIdOOK",
                principalTable: "SCUsers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCreditContractTerms_SCUsers_UserIdOOK",
                table: "LoanApplicationCreditContractTerms");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCreditContractTerms_UserIdOOK",
                table: "LoanApplicationCreditContractTerms");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "AnswerOOK",
                table: "LoanApplicationCreditContractTerms");

            migrationBuilder.DropColumn(
                name: "UserIdOOK",
                table: "LoanApplicationCreditContractTerms");
        }
    }
}
