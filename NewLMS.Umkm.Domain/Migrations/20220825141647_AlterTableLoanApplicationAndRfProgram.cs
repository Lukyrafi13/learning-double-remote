using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationAndRfProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RfProgramId",
                table: "LoanApplications",
                type: "nvarchar(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfProgramId",
                table: "LoanApplications",
                column: "RfProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfPrograms_RfProgramId",
                table: "LoanApplications",
                column: "RfProgramId",
                principalTable: "RfPrograms",
                principalColumn: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfPrograms_RfProgramId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_RfProgramId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfProgramId",
                table: "LoanApplications");
        }
    }
}
