using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfInsuranceCompanyChangeZipCodeIdAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfInsuranceCompanies_RfZipCodes_RfZipCodeId",
                table: "RfInsuranceCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "RfInsuranceCompanies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RfInsuranceCompanies_RfZipCodes_RfZipCodeId",
                table: "RfInsuranceCompanies",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfInsuranceCompanies_RfZipCodes_RfZipCodeId",
                table: "RfInsuranceCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "RfZipCodeId",
                table: "RfInsuranceCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RfInsuranceCompanies_RfZipCodes_RfZipCodeId",
                table: "RfInsuranceCompanies",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
