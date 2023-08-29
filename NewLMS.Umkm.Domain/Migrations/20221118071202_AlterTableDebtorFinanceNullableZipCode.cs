using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDebtorFinanceNullableZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorFinance_RfZipCodes_RfZipCodeId",
                table: "DebtorFinance");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorFinance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorFinance_RfZipCodes_RfZipCodeId",
                table: "DebtorFinance",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorFinance_RfZipCodes_RfZipCodeId",
                table: "DebtorFinance");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorFinance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorFinance_RfZipCodes_RfZipCodeId",
                table: "DebtorFinance",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
