using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class ReconsturctSLIKDebtorsFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequestDebtors_Debtors_DebtorId",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequestDebtors_DebtorId",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "DebtorId",
                table: "SLIKRequestDebtors");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "SLIKRequestDebtors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPWP",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoIdentity",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfBirth",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "NPWP",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "NoIdentity",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                table: "SLIKRequestDebtors");

            migrationBuilder.AddColumn<string>(
                name: "DebtorId",
                table: "SLIKRequestDebtors",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_DebtorId",
                table: "SLIKRequestDebtors",
                column: "DebtorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequestDebtors_Debtors_DebtorId",
                table: "SLIKRequestDebtors",
                column: "DebtorId",
                principalTable: "Debtors",
                principalColumn: "NoIdentity");
        }
    }
}
