using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationAddColumnRfSubProgramId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RfSubProductId",
                table: "LoanApplications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfSubProductId",
                table: "LoanApplications",
                column: "RfSubProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfSubProducts_RfSubProductId",
                table: "LoanApplications",
                column: "RfSubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfSubProducts_RfSubProductId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_RfSubProductId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfSubProductId",
                table: "LoanApplications");
        }
    }
}
