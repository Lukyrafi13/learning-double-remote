using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SPPKIntegrateSCJabatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanMKK1Id",
                table: "SPPKs",
                column: "RFJabatanMKK1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanMKK2Id",
                table: "SPPKs",
                column: "RFJabatanMKK2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanMKK3Id",
                table: "SPPKs",
                column: "RFJabatanMKK3Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanMKK4Id",
                table: "SPPKs",
                column: "RFJabatanMKK4Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanMKK5Id",
                table: "SPPKs",
                column: "RFJabatanMKK5Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanSKK1Id",
                table: "SPPKs",
                column: "RFJabatanSKK1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanSKK2Id",
                table: "SPPKs",
                column: "RFJabatanSKK2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanSPPK1Id",
                table: "SPPKs",
                column: "RFJabatanSPPK1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKs_RFJabatanSPPK2Id",
                table: "SPPKs",
                column: "RFJabatanSPPK2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK1Id",
                table: "SPPKs",
                column: "RFJabatanMKK1Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK2Id",
                table: "SPPKs",
                column: "RFJabatanMKK2Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK3Id",
                table: "SPPKs",
                column: "RFJabatanMKK3Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK4Id",
                table: "SPPKs",
                column: "RFJabatanMKK4Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK5Id",
                table: "SPPKs",
                column: "RFJabatanMKK5Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSKK1Id",
                table: "SPPKs",
                column: "RFJabatanSKK1Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSKK2Id",
                table: "SPPKs",
                column: "RFJabatanSKK2Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSPPK1Id",
                table: "SPPKs",
                column: "RFJabatanSPPK1Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSPPK2Id",
                table: "SPPKs",
                column: "RFJabatanSPPK2Id",
                principalTable: "SCJabatans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK1Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK2Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK3Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK4Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanMKK5Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSKK1Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSKK2Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSPPK1Id",
                table: "SPPKs");

            migrationBuilder.DropForeignKey(
                name: "FK_SPPKs_SCJabatans_RFJabatanSPPK2Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanMKK1Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanMKK2Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanMKK3Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanMKK4Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanMKK5Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanSKK1Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanSKK2Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanSPPK1Id",
                table: "SPPKs");

            migrationBuilder.DropIndex(
                name: "IX_SPPKs_RFJabatanSPPK2Id",
                table: "SPPKs");
        }
    }
}
