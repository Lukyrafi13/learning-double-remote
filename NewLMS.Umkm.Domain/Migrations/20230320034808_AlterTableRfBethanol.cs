using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableRfBethanol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovalBy",
                table: "RfBethanol",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "RfBethanol",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckerBy",
                table: "RfBethanol",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckerDate",
                table: "RfBethanol",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproval",
                table: "RfBethanol",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecker",
                table: "RfBethanol",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequestBy",
                table: "RfBethanol",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "RfBethanol",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestStatus",
                table: "RfBethanol",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusApproval",
                table: "RfBethanol",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusChecker",
                table: "RfBethanol",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalBy",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "CheckerBy",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "CheckerDate",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "IsApproval",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "IsChecker",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "RequestBy",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "StatusApproval",
                table: "RfBethanol");

            migrationBuilder.DropColumn(
                name: "StatusChecker",
                table: "RfBethanol");
        }
    }
}
