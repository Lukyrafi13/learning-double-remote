using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableRfProgramMakerChecker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedBy",
                table: "RfPrograms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "RfPrograms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsApproved",
                table: "RfPrograms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecker",
                table: "RfPrograms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "RfPrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfPrograms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_DefProvPctFee",
                table: "RfPrograms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TEMP_Description",
                table: "RfPrograms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TEMP_EndDate",
                table: "RfPrograms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_MaxProvPctFee",
                table: "RfPrograms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "TEMP_ModifyingProv",
                table: "RfPrograms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TEMP_RepaymentDisc",
                table: "RfPrograms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TEMP_StartDate",
                table: "RfPrograms",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "IsChecker",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_DefProvPctFee",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_Description",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_EndDate",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_MaxProvPctFee",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_ModifyingProv",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_RepaymentDisc",
                table: "RfPrograms");

            migrationBuilder.DropColumn(
                name: "TEMP_StartDate",
                table: "RfPrograms");
        }
    }
}
