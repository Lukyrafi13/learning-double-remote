using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddForeignKeyStageIdToLoanApplicationStageLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStageLogs_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                table: "LoanApplicationStageLogs");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationStageLogs_StageId",
                table: "LoanApplicationStageLogs");
        }
    }
}
