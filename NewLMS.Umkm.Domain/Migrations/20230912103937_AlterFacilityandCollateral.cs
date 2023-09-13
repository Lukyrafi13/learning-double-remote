using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterFacilityandCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlacementCountryCode",
                table: "LoanApplicationFacilities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentCode",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_PlacementCountryCode",
                table: "LoanApplicationFacilities",
                column: "PlacementCountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_DocumentCode",
                table: "LoanApplicationCollaterals",
                column: "DocumentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfDocuments_DocumentCode",
                table: "LoanApplicationCollaterals",
                column: "DocumentCode",
                principalTable: "RfDocuments",
                principalColumn: "DocumentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationFacilities_RfPlacementCountries_PlacementCountryCode",
                table: "LoanApplicationFacilities",
                column: "PlacementCountryCode",
                principalTable: "RfPlacementCountries",
                principalColumn: "PlacementCountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfDocuments_DocumentCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationFacilities_RfPlacementCountries_PlacementCountryCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationFacilities_PlacementCountryCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_DocumentCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "PlacementCountryCode",
                table: "LoanApplicationFacilities");

            migrationBuilder.DropColumn(
                name: "DocumentCode",
                table: "LoanApplicationCollaterals");
        }
    }
}
