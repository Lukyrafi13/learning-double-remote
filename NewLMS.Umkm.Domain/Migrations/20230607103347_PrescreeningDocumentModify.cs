using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDocumentModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFTipeDokumenId",
                table: "PrescreeningDokumens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VerifiedByAdmin",
                table: "PrescreeningDokumens",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDokumens_RFTipeDokumenId",
                table: "PrescreeningDokumens",
                column: "RFTipeDokumenId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescreeningDokumens_RFTipeDokumens_RFTipeDokumenId",
                table: "PrescreeningDokumens",
                column: "RFTipeDokumenId",
                principalTable: "RFTipeDokumens",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescreeningDokumens_RFTipeDokumens_RFTipeDokumenId",
                table: "PrescreeningDokumens");

            migrationBuilder.DropIndex(
                name: "IX_PrescreeningDokumens_RFTipeDokumenId",
                table: "PrescreeningDokumens");

            migrationBuilder.DropColumn(
                name: "RFTipeDokumenId",
                table: "PrescreeningDokumens");

            migrationBuilder.DropColumn(
                name: "VerifiedByAdmin",
                table: "PrescreeningDokumens");
        }
    }
}
