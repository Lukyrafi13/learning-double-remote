using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDeskripsiTBO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFSiklusUsahas_RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.AddColumn<string>(
                name: "DeskripsiTBO",
                table: "PrescreeningDokumens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiklusUsahaMonth",
                table: "Apps",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeskripsiTBO",
                table: "PrescreeningDokumens");

            migrationBuilder.DropColumn(
                name: "SiklusUsahaMonth",
                table: "Apps");

            migrationBuilder.AddColumn<Guid>(
                name: "RFSiklusUsahaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSiklusUsahaId",
                table: "Apps",
                column: "RFSiklusUsahaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFSiklusUsahas_RFSiklusUsahaId",
                table: "Apps",
                column: "RFSiklusUsahaId",
                principalTable: "RFSiklusUsahas",
                principalColumn: "Id");
        }
    }
}
