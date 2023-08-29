using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class UpdateTableLoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoIdentity",
                table: "LoanApplications",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_NoIdentity",
                table: "LoanApplications",
                column: "NoIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Debtors_NoIdentity",
                table: "LoanApplications",
                column: "NoIdentity",
                principalTable: "Debtors",
                principalColumn: "NoIdentity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Debtors_NoIdentity",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_NoIdentity",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "NoIdentity",
                table: "LoanApplications");
        }
    }
}
