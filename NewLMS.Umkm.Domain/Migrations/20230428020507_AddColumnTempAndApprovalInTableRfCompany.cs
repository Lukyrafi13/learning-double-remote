using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnTempAndApprovalInTableRfCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "RfCompanies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RfCompanies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "RfCompanies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheker",
                table: "RfCompanies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfCompanies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Temp_Active",
                table: "RfCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Temp_Address",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Temp_Allowances",
                table: "RfCompanies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Temp_BranchId",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_City",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_CompId",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_CompName",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_CoreCode",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_District",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_Email",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_EscrowNo",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_FaxArea",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_FaxNumber",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Temp_MaxLimit",
                table: "RfCompanies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temp_MaxRpc",
                table: "RfCompanies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Temp_MaxTenor",
                table: "RfCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Temp_MaximumYearBeforeRetirement",
                table: "RfCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Temp_Mou",
                table: "RfCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Temp_Neighborhoods",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_PhoneArea",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_PhoneExt",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_PhoneNumber",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_Province",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_RT",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temp_RW",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Temp_RpcPortion",
                table: "RfCompanies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Temp_Salaray",
                table: "RfCompanies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Temp_ZIPCode",
                table: "RfCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "IsCheker",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Active",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Address",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Allowances",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_BranchId",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_City",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_CompId",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_CompName",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_CoreCode",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_District",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Email",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_EscrowNo",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_FaxArea",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_FaxNumber",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_MaxLimit",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_MaxRpc",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_MaxTenor",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_MaximumYearBeforeRetirement",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Mou",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Neighborhoods",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_PhoneArea",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_PhoneExt",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_PhoneNumber",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Province",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_RT",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_RW",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_RpcPortion",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_Salaray",
                table: "RfCompanies");

            migrationBuilder.DropColumn(
                name: "Temp_ZIPCode",
                table: "RfCompanies");
        }
    }
}
