using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDocumentsChangeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "SLIKRequestId",
                table: "Documents",
                newName: "LoanApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_SLIKRequestId",
                table: "Documents",
                newName: "IX_Documents_LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_LoanApplications_LoanApplicationId",
                table: "Documents",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_LoanApplications_LoanApplicationId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "LoanApplicationId",
                table: "Documents",
                newName: "SLIKRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_LoanApplicationId",
                table: "Documents",
                newName: "IX_Documents_SLIKRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents",
                column: "SLIKRequestId",
                principalTable: "SLIKRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
