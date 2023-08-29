using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableSubProductMakerChecker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckerBy",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "CheckerDate",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "StatusApproval",
                table: "RfProducts");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RfSubProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "RfSubProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RfSubProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsApproved",
                table: "RfSubProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecker",
                table: "RfSubProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfSubProducts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TEMP_BjbMusisi",
                table: "RfSubProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_BlockParam",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_ChargeCodeFeeAdministration",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_ChargeCodeInsurance",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_ChargeCodeProvisi",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_CoreCode",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_DIMType",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefAdmPcmFee",
                table: "RfSubProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_DefIntType",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefProvPctFee",
                table: "RfSubProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_DefpayCode",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_Description",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_DivisionCode",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_GradePeriodPension",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TEMP_IsGracePeriod",
                table: "RfSubProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxBlockParam",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxPlanfond",
                table: "RfSubProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxProvPctFee",
                table: "RfSubProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaximumMonthBeforeRetirement",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaximumYearBeforeRetirement",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MinBlockParam",
                table: "RfSubProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_Payroll",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_ProductId",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_SchemaMaxInstallment",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_TplSurveyCode",
                table: "RfSubProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StatusChecker",
                table: "RfProducts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsApproved",
                table: "RfProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "IsChecker",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_BjbMusisi",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_BlockParam",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_ChargeCodeFeeAdministration",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_ChargeCodeInsurance",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_ChargeCodeProvisi",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_CoreCode",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DIMType",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefAdmPcmFee",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefIntType",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefProvPctFee",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefpayCode",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_Description",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DivisionCode",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_GradePeriodPension",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_IsGracePeriod",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxBlockParam",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxPlanfond",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxProvPctFee",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaximumMonthBeforeRetirement",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaximumYearBeforeRetirement",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MinBlockParam",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_Payroll",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_ProductId",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_SchemaMaxInstallment",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_TplSurveyCode",
                table: "RfSubProducts");

            migrationBuilder.AlterColumn<string>(
                name: "StatusChecker",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "RfProducts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CheckerBy",
                table: "RfProducts",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckerDate",
                table: "RfProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApproval",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
