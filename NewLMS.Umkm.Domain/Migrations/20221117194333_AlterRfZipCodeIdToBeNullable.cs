using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterRfZipCodeIdToBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_RfZipCodes_RfZipCodeId",
                table: "Debtors");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "Debtors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorEmergencies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorCouples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_RfZipCodes_RfZipCodeId",
                table: "Debtors",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples");

            migrationBuilder.DropForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_RfZipCodes_RfZipCodeId",
                table: "Debtors");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorEmergencies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorCouples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_RfZipCodes_RfZipCodeId",
                table: "Debtors",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
