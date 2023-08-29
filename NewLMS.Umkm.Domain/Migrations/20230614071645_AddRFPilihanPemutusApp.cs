using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddRFPilihanPemutusApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFPilihanPemutusId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFPilihanPemutusId",
                table: "Apps",
                column: "RFPilihanPemutusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFPilihanPemutuss_RFPilihanPemutusId",
                table: "Apps",
                column: "RFPilihanPemutusId",
                principalTable: "RFPilihanPemutuss",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFPilihanPemutuss_RFPilihanPemutusId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFPilihanPemutusId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFPilihanPemutusId",
                table: "Apps");
        }
    }
}
