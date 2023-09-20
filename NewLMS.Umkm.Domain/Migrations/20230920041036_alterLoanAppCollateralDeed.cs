using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterLoanAppCollateralDeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfDeedId",
                table: "LoanApplicationCollaterals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_TypeOfDeedId",
                table: "LoanApplicationCollaterals",
                column: "TypeOfDeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfParameterDetails_TypeOfDeedId",
                table: "LoanApplicationCollaterals",
                column: "TypeOfDeedId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfParameterDetails_TypeOfDeedId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_TypeOfDeedId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "TypeOfDeedId",
                table: "LoanApplicationCollaterals");
        }
    }
}
