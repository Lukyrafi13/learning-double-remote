using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditProspectEntityDebitur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DebiturId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_DebiturId",
                table: "Prospects",
                column: "DebiturId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_Debiturs_DebiturId",
                table: "Prospects",
                column: "DebiturId",
                principalTable: "Debiturs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_Debiturs_DebiturId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_DebiturId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "DebiturId",
                table: "Prospects");
        }
    }
}
