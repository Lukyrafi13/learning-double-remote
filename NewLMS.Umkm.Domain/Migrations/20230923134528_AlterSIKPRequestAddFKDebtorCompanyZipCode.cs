using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPRequestAddFKDebtorCompanyZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorCompanyRfZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.DropIndex(
                name: "IX_SIKPRequests_DebtorCompanyRfZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyRfZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorCompanyZipCodeId",
                table: "SIKPRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorCompanyZipCodeId",
                table: "SIKPRequests",
                column: "DebtorCompanyZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorCompanyZipCodeId",
                table: "SIKPRequests",
                column: "DebtorCompanyZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorCompanyZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.DropIndex(
                name: "IX_SIKPRequests_DebtorCompanyZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorCompanyZipCodeId",
                table: "SIKPRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DebtorCompanyRfZipCodeId",
                table: "SIKPRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorCompanyRfZipCodeId",
                table: "SIKPRequests",
                column: "DebtorCompanyRfZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorCompanyRfZipCodeId",
                table: "SIKPRequests",
                column: "DebtorCompanyRfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }
    }
}
