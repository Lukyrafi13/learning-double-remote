using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class FKSiklusUsaha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFSiklusUsahaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFSiklusUsahaPokokId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSiklusUsahaId",
                table: "Apps",
                column: "RFSiklusUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSiklusUsahaPokokId",
                table: "Apps",
                column: "RFSiklusUsahaPokokId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFSiklusUsahaPokoks_RFSiklusUsahaPokokId",
                table: "Apps",
                column: "RFSiklusUsahaPokokId",
                principalTable: "RFSiklusUsahaPokoks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFSiklusUsahas_RFSiklusUsahaId",
                table: "Apps",
                column: "RFSiklusUsahaId",
                principalTable: "RFSiklusUsahas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFSiklusUsahaPokoks_RFSiklusUsahaPokokId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFSiklusUsahas_RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFSiklusUsahaPokokId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFSiklusUsahaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFSiklusUsahaPokokId",
                table: "Apps");
        }
    }
}
