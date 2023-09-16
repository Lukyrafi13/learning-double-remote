using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPReqResNullabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorZipCodeId",
                table: "SIKPResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorZipCodeId",
                table: "SIKPRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorZipCodeId",
                table: "SIKPRequests",
                column: "DebtorZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorZipCodeId",
                table: "SIKPResponses",
                column: "DebtorZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorZipCodeId",
                table: "SIKPRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorZipCodeId",
                table: "SIKPResponses");

            migrationBuilder.AlterColumn<int>(
                name: "DebtorZipCodeId",
                table: "SIKPResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DebtorZipCodeId",
                table: "SIKPRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfZipCodes_DebtorZipCodeId",
                table: "SIKPRequests",
                column: "DebtorZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfZipCodes_DebtorZipCodeId",
                table: "SIKPResponses",
                column: "DebtorZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
