using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RelationPrescreeningCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFCollateralBCId",
                table: "PrescreeningDokumens",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDokumens_RFCollateralBCId",
                table: "PrescreeningDokumens",
                column: "RFCollateralBCId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescreeningDokumens_RFColLateralBCs_RFCollateralBCId",
                table: "PrescreeningDokumens",
                column: "RFCollateralBCId",
                principalTable: "RFColLateralBCs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescreeningDokumens_RFColLateralBCs_RFCollateralBCId",
                table: "PrescreeningDokumens");

            migrationBuilder.DropIndex(
                name: "IX_PrescreeningDokumens_RFCollateralBCId",
                table: "PrescreeningDokumens");

            migrationBuilder.DropColumn(
                name: "RFCollateralBCId",
                table: "PrescreeningDokumens");
        }
    }
}
