using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanCollateraladdReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CollateralBCId",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_CollateralBCId",
                table: "LoanApplicationCollaterals",
                column: "CollateralBCId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfCollateralBCs_CollateralBCId",
                table: "LoanApplicationCollaterals",
                column: "CollateralBCId",
                principalTable: "RfCollateralBCs",
                principalColumn: "CollateralCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfCollateralBCs_CollateralBCId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_CollateralBCId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.AlterColumn<string>(
                name: "CollateralBCId",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
