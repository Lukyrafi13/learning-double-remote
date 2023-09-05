using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterTableDebtorCompanyNullableZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                table: "DebtorCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCodeId",
                table: "DebtorCompanies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                table: "DebtorCompanies",
                column: "ZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                table: "DebtorCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCodeId",
                table: "DebtorCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                table: "DebtorCompanies",
                column: "ZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
