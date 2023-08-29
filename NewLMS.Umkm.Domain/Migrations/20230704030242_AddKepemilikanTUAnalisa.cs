using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddKepemilikanTUAnalisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LamaUsahaBidangIni",
                table: "Analisas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFKepemilikanTUId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFKepemilikanTUId",
                table: "Analisas",
                column: "RFKepemilikanTUId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFKepemilikanTUs_RFKepemilikanTUId",
                table: "Analisas",
                column: "RFKepemilikanTUId",
                principalTable: "RFKepemilikanTUs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFKepemilikanTUs_RFKepemilikanTUId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFKepemilikanTUId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "LamaUsahaBidangIni",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFKepemilikanTUId",
                table: "Analisas");
        }
    }
}
