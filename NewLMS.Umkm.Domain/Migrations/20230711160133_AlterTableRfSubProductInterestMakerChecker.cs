using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableRfSubProductInterestMakerChecker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "RfSubProductInterests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RfSubProductInterests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsApproved",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecker",
                table: "RfSubProductInterests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfSubProductInterests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TEMP_Active",
                table: "RfSubProductInterests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_BaseRate",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_BaseRateYear",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TEMP_BatchId",
                table: "RfSubProductInterests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_BatchIdSeq",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_BranchId",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_CompanyId",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TEMP_EndDate",
                table: "RfSubProductInterests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_GolCode",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_GracePeriodCode",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_InterestNew",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_InterestPromoType",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_InterestRepeat",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_InterestTopUp",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_InterestType",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_JobCode",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxAge",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxTenor",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MinAge",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MinTenor",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MusisiNew",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MusisiRepeat",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MusisiTopUp",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_ParamSpread",
                table: "RfSubProductInterests",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_PngktCode",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_ProductId",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TEMP_StartDate",
                table: "RfSubProductInterests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_SubProductId",
                table: "RfSubProductInterests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_TplPrio",
                table: "RfSubProductInterests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "IsChecker",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_Active",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_BaseRate",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_BaseRateYear",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_BatchId",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_BatchIdSeq",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_BranchId",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_CompanyId",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_EndDate",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_GolCode",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_GracePeriodCode",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_InterestNew",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_InterestPromoType",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_InterestRepeat",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_InterestTopUp",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_InterestType",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_JobCode",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxAge",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxTenor",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MinAge",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MinTenor",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MusisiNew",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MusisiRepeat",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_MusisiTopUp",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_ParamSpread",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_PngktCode",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_ProductId",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_StartDate",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_SubProductId",
                table: "RfSubProductInterests");

            migrationBuilder.DropColumn(
                name: "TEMP_TplPrio",
                table: "RfSubProductInterests");
        }
    }
}
