using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyProspectEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFKategoriId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RFKodeDinasId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFKategoriId",
                table: "Prospects",
                column: "RFKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFKodeDinasId",
                table: "Prospects",
                column: "RFKodeDinasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFGenders_RFKodeDinasId",
                table: "Prospects",
                column: "RFKodeDinasId",
                principalTable: "RFGenders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFKategoris_RFKategoriId",
                table: "Prospects",
                column: "RFKategoriId",
                principalTable: "RFKategoris",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFGenders_RFKodeDinasId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFKategoris_RFKategoriId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFKategoriId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFKodeDinasId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFKategoriId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFKodeDinasId",
                table: "Prospects");
        }
    }
}
