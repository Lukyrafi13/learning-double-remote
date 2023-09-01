using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterProspectcopmZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RFDocument_RFDocumentId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMappingAgunan2_RfMappingCollateralId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RFDocuments_RFDocumentId",
                table: "LoanApplicationCollaterals",
                column: "RFDocumentId",
                principalTable: "RFDocuments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMappingAgunan2s_RfMappingCollateralId",
                table: "LoanApplicationCollaterals",
                column: "RfMappingCollateralId",
                principalTable: "RFMappingAgunan2s",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RFDocuments_RFDocumentId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMappingAgunan2s_RfMappingCollateralId",
                table: "LoanApplicationCollaterals");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RFDocument_RFDocumentId",
                table: "LoanApplicationCollaterals",
                column: "RFDocumentId",
                principalTable: "RFDocument",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RFMappingAgunan2_RfMappingCollateralId",
                table: "LoanApplicationCollaterals",
                column: "RfMappingCollateralId",
                principalTable: "RFMappingAgunan2",
                principalColumn: "Id");
        }
    }
}
