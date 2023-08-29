using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppRefineAtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFHomestaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SeumurHidup",
                table: "Apps",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFHomestaId",
                table: "Apps",
                column: "RFHomestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFHOMESTA_RFHomestaId",
                table: "Apps",
                column: "RFHomestaId",
                principalTable: "RFHOMESTA",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFHOMESTA_RFHomestaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFHomestaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFHomestaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "SeumurHidup",
                table: "Apps");
        }
    }
}
