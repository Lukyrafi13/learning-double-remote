using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyDebiturII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs");

            migrationBuilder.AlterColumn<int>(
                name: "RFZipCodeId",
                table: "Debiturs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs",
                column: "RFZipCodeId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs");

            migrationBuilder.AlterColumn<int>(
                name: "RFZipCodeId",
                table: "Debiturs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs",
                column: "RFZipCodeId",
                principalTable: "RFZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
