using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddMissingSCOIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppKeyPersons_Apps_AppId",
                table: "AppKeyPersons");

            migrationBuilder.AlterColumn<string>(
                name: "ExecutedBy",
                table: "ProspectStageLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppKeyPersons_Apps_AppId",
                table: "AppKeyPersons",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppKeyPersons_Apps_AppId",
                table: "AppKeyPersons");

            migrationBuilder.AlterColumn<string>(
                name: "ExecutedBy",
                table: "ProspectStageLogs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppKeyPersons_Apps_AppId",
                table: "AppKeyPersons",
                column: "AppId",
                principalTable: "Apps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
