using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableProductAddTempColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "RfProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RfProducts",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "RfProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecker",
                table: "RfProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApproval",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_BlockParam",
                table: "RfProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_CoreCode",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_CoreProvCode",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefAdminFee",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefInterest",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefProvPctFee",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefSpread",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_DefTenor",
                table: "RfProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_DefintType",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_Description",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_LimitColumnReq",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxAge",
                table: "RfProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxInterest",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxLimit",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxProvPctFee",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxRpc",
                table: "RfProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TEMP_MaxTenor",
                table: "RfProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MinInterest",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_PenaltyPSJT",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_PenaltyTopup",
                table: "RfProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_Type",
                table: "RfProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors",
                column: "LoanApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "CheckerBy",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "CheckerDate",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "IsChecker",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "StatusApproval",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_BlockParam",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_CoreCode",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_CoreProvCode",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefAdminFee",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefInterest",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefProvPctFee",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefSpread",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefTenor",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_DefintType",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_Description",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_LimitColumnReq",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxAge",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxInterest",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxLimit",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxProvPctFee",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxRpc",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxTenor",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_MinInterest",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_PenaltyPSJT",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_PenaltyTopup",
                table: "RfProducts");

            migrationBuilder.DropColumn(
                name: "TEMP_Type",
                table: "RfProducts");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorGuarantors_LoanApplicationId",
                table: "DebtorGuarantors",
                column: "LoanApplicationId");
        }
    }
}
