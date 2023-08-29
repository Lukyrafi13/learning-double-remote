using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSLIKRequestChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SLIKRequests",
                table: "SLIKRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SLIKRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.AlterColumn<Guid>(
                name: "SLIKRequestId",
                table: "SLIKRequestDebtors",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SLIKRequestId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SLIKRequests",
                table: "SLIKRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents",
                column: "SLIKRequestId",
                principalTable: "SLIKRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                table: "SLIKRequestDebtors",
                column: "SLIKRequestId",
                principalTable: "SLIKRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SLIKRequests",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SLIKRequests");

            migrationBuilder.AlterColumn<string>(
                name: "SLIKRequestId",
                table: "SLIKRequestDebtors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SLIKRequestId",
                table: "Documents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SLIKRequests",
                table: "SLIKRequests",
                column: "SLIKRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_SLIKRequests_SLIKRequestId",
                table: "Documents",
                column: "SLIKRequestId",
                principalTable: "SLIKRequests",
                principalColumn: "SLIKRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                table: "SLIKRequestDebtors",
                column: "SLIKRequestId",
                principalTable: "SLIKRequests",
                principalColumn: "SLIKRequestId");
        }
    }
}
