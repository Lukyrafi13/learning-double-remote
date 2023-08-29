using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PersiapanAkadAsuransiJenis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkadAsuransis_RFJenisAsuransiId",
                table: "PersiapanAkadAsuransis",
                column: "RFJenisAsuransiId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersiapanAkadAsuransis_RFJenisAsuransis_RFJenisAsuransiId",
                table: "PersiapanAkadAsuransis",
                column: "RFJenisAsuransiId",
                principalTable: "RFJenisAsuransis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersiapanAkadAsuransis_RFJenisAsuransis_RFJenisAsuransiId",
                table: "PersiapanAkadAsuransis");

            migrationBuilder.DropIndex(
                name: "IX_PersiapanAkadAsuransis_RFJenisAsuransiId",
                table: "PersiapanAkadAsuransis");
        }
    }
}
