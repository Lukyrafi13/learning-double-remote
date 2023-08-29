using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationComplinceSheetAddCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollateralType",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SufficientCollateral",
                table: "LoanApplicationComplienceSheets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralOwnership");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralType",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralType");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                column: "ProofOfCollateralOwnership");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_SufficientCollateral",
                table: "LoanApplicationComplienceSheets",
                column: "SufficientCollateral");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralOwnership",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralType",
                table: "LoanApplicationComplienceSheets",
                column: "CollateralType",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets",
                column: "ProofOfCollateralOwnership",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_SufficientCollateral",
                table: "LoanApplicationComplienceSheets",
                column: "SufficientCollateral",
                principalTable: "RfCSBPs",
                principalColumn: "RfCSBPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CollateralType",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationComplienceSheets_RfCSBPs_SufficientCollateral",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_CollateralType",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationComplienceSheets_SufficientCollateral",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "CollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "CollateralType",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "ProofOfCollateralOwnership",
                table: "LoanApplicationComplienceSheets");

            migrationBuilder.DropColumn(
                name: "SufficientCollateral",
                table: "LoanApplicationComplienceSheets");
        }
    }
}
