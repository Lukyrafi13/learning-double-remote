using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyDebitur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodePos",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "KodePosTempatTinggal",
                table: "Debiturs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Debiturs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeId",
                table: "Debiturs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeTempatTinggalId",
                table: "Debiturs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFZipCodeId",
                table: "Debiturs",
                column: "RFZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFZipCodeTempatTinggalId",
                table: "Debiturs",
                column: "RFZipCodeTempatTinggalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs",
                column: "RFZipCodeId",
                principalTable: "RFZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeTempatTinggalId",
                table: "Debiturs",
                column: "RFZipCodeTempatTinggalId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeId",
                table: "Debiturs");

            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFZipCodes_RFZipCodeTempatTinggalId",
                table: "Debiturs");

            migrationBuilder.DropIndex(
                name: "IX_Debiturs_RFZipCodeId",
                table: "Debiturs");

            migrationBuilder.DropIndex(
                name: "IX_Debiturs_RFZipCodeTempatTinggalId",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "RFZipCodeId",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "RFZipCodeTempatTinggalId",
                table: "Debiturs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "Debiturs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodePos",
                table: "Debiturs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodePosTempatTinggal",
                table: "Debiturs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
