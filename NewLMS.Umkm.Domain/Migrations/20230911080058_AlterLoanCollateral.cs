using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<double>(
                name: "BuildingArea",
                table: "LoanApplicationCollaterals",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingPermit",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityDomisili",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LanArea",
                table: "LoanApplicationCollaterals",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MachineNumber",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NJOPPBBNumber",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOPNumber",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehClassCode",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehMakerCode",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehModelCode",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearProduction",
                table: "LoanApplicationCollaterals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehClassCode",
                table: "LoanApplicationCollaterals",
                column: "VehClassCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehMakerCode",
                table: "LoanApplicationCollaterals",
                column: "VehMakerCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_VehModelCode",
                table: "LoanApplicationCollaterals",
                column: "VehModelCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehClasss_VehClassCode",
                table: "LoanApplicationCollaterals",
                column: "VehClassCode",
                principalTable: "RfVehClasss",
                principalColumn: "VehClassCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehMakers_VehMakerCode",
                table: "LoanApplicationCollaterals",
                column: "VehMakerCode",
                principalTable: "RfVehMakers",
                principalColumn: "VehMakerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehModels_VehModelCode",
                table: "LoanApplicationCollaterals",
                column: "VehModelCode",
                principalTable: "RfVehModels",
                principalColumn: "VehModelCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehClasss_VehClassCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehMakers_VehMakerCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfVehModels_VehModelCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_VehClassCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_VehMakerCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_VehModelCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "BuildingArea",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "BuildingPermit",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "CityDomisili",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "LanArea",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "MachineNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NJOPPBBNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NOPNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "VehClassCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "VehMakerCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "VehModelCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "YearProduction",
                table: "LoanApplicationCollaterals");
        }
    }
}
