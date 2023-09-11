using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications");
        }
    }
}
