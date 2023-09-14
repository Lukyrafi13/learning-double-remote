using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterLoanAppCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityDocumentCollateral",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateMeasurementLetterNumber",
                table: "LoanApplicationCollaterals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictDocumentCollateral",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EastBoundaries",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandLocation",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementLetterNumber",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementLetterNumberImageSituation",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameCollateralHolder",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameMarketLocation",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeigborhoodDocumentCollateral",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorthBoundaries",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceDocumentCollateral",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RangkingHT",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SouthBoundaries",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportationTypeCode",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WestBoundaries",
                table: "LoanApplicationCollaterals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OwnerIdentityExpireDate",
                table: "LoanApplicationCollateralOwners",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_TransportationTypeCode",
                table: "LoanApplicationCollaterals",
                column: "TransportationTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollaterals_RfTransportationTypes_TransportationTypeCode",
                table: "LoanApplicationCollaterals",
                column: "TransportationTypeCode",
                principalTable: "RfTransportationTypes",
                principalColumn: "TransportationTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollaterals_RfTransportationTypes_TransportationTypeCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollaterals_TransportationTypeCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "CityDocumentCollateral",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "DateMeasurementLetterNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "DistrictDocumentCollateral",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "EastBoundaries",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "LandLocation",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "MeasurementLetterNumber",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "MeasurementLetterNumberImageSituation",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NameCollateralHolder",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NameMarketLocation",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NeigborhoodDocumentCollateral",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "NorthBoundaries",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "ProvinceDocumentCollateral",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "RangkingHT",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "SouthBoundaries",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "TransportationTypeCode",
                table: "LoanApplicationCollaterals");

            migrationBuilder.DropColumn(
                name: "WestBoundaries",
                table: "LoanApplicationCollaterals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OwnerIdentityExpireDate",
                table: "LoanApplicationCollateralOwners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
