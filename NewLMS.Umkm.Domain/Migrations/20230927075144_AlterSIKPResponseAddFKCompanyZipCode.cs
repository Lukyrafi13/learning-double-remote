using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPResponseAddFKCompanyZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorCompanyRfZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.DropIndex(
                name: "IX_SIKPResponses_DebtorCompanyRfZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyRfZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorCompanyZipCodeId",
                table: "SIKPResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorCompanyZipCodeId",
                table: "SIKPResponses",
                column: "DebtorCompanyZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorCompanyZipCodeId",
                table: "SIKPResponses",
                column: "DebtorCompanyZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorCompanyZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.DropIndex(
                name: "IX_SIKPResponses_DebtorCompanyZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorCompanyZipCodeId",
                table: "SIKPResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DebtorCompanyRfZipCodeId",
                table: "SIKPResponses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorCompanyRfZipCodeId",
                table: "SIKPResponses",
                column: "DebtorCompanyRfZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorCompanyRfZipCodeId",
                table: "SIKPResponses",
                column: "DebtorCompanyRfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }
    }
}
