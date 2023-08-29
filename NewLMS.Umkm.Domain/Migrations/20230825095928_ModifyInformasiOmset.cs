using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyInformasiOmset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformasiOmsets_RFBentukLahans_BentukLahanUsahaId",
                table: "InformasiOmsets");

            migrationBuilder.DropForeignKey(
                name: "FK_InformasiOmsets_RFSatuanLuass_LuasLahanUsahaId",
                table: "InformasiOmsets");

            migrationBuilder.DropIndex(
                name: "IX_InformasiOmsets_BentukLahanUsahaId",
                table: "InformasiOmsets");

            migrationBuilder.DropColumn(
                name: "BentukLahanUsaha",
                table: "InformasiOmsets");

            migrationBuilder.RenameColumn(
                name: "PenjualanTahunan",
                table: "InformasiOmsets",
                newName: "PenjualanTahunanOmset");

            migrationBuilder.RenameColumn(
                name: "LuasLahanUsahaId",
                table: "InformasiOmsets",
                newName: "RFLuasLahanUsahaId");

            migrationBuilder.RenameColumn(
                name: "KekayaanBersih",
                table: "InformasiOmsets",
                newName: "KekayaanBersihOmset");

            migrationBuilder.RenameColumn(
                name: "BentukLahanUsahaId",
                table: "InformasiOmsets",
                newName: "RFBentukLahanUsahaId");

            migrationBuilder.RenameIndex(
                name: "IX_InformasiOmsets_LuasLahanUsahaId",
                table: "InformasiOmsets",
                newName: "IX_InformasiOmsets_RFLuasLahanUsahaId");

            migrationBuilder.AddColumn<Guid>(
                name: "RFBentukLahanUsaha",
                table: "InformasiOmsets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformasiOmsets_RFBentukLahanUsaha",
                table: "InformasiOmsets",
                column: "RFBentukLahanUsaha");

            migrationBuilder.AddForeignKey(
                name: "FK_InformasiOmsets_RFBentukLahans_RFLuasLahanUsahaId",
                table: "InformasiOmsets",
                column: "RFLuasLahanUsahaId",
                principalTable: "RFBentukLahans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InformasiOmsets_RFSatuanLuass_RFBentukLahanUsaha",
                table: "InformasiOmsets",
                column: "RFBentukLahanUsaha",
                principalTable: "RFSatuanLuass",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformasiOmsets_RFBentukLahans_RFLuasLahanUsahaId",
                table: "InformasiOmsets");

            migrationBuilder.DropForeignKey(
                name: "FK_InformasiOmsets_RFSatuanLuass_RFBentukLahanUsaha",
                table: "InformasiOmsets");

            migrationBuilder.DropIndex(
                name: "IX_InformasiOmsets_RFBentukLahanUsaha",
                table: "InformasiOmsets");

            migrationBuilder.DropColumn(
                name: "RFBentukLahanUsaha",
                table: "InformasiOmsets");

            migrationBuilder.RenameColumn(
                name: "RFLuasLahanUsahaId",
                table: "InformasiOmsets",
                newName: "LuasLahanUsahaId");

            migrationBuilder.RenameColumn(
                name: "RFBentukLahanUsahaId",
                table: "InformasiOmsets",
                newName: "BentukLahanUsahaId");

            migrationBuilder.RenameColumn(
                name: "PenjualanTahunanOmset",
                table: "InformasiOmsets",
                newName: "PenjualanTahunan");

            migrationBuilder.RenameColumn(
                name: "KekayaanBersihOmset",
                table: "InformasiOmsets",
                newName: "KekayaanBersih");

            migrationBuilder.RenameIndex(
                name: "IX_InformasiOmsets_RFLuasLahanUsahaId",
                table: "InformasiOmsets",
                newName: "IX_InformasiOmsets_LuasLahanUsahaId");

            migrationBuilder.AddColumn<int>(
                name: "BentukLahanUsaha",
                table: "InformasiOmsets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformasiOmsets_BentukLahanUsahaId",
                table: "InformasiOmsets",
                column: "BentukLahanUsahaId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformasiOmsets_RFBentukLahans_BentukLahanUsahaId",
                table: "InformasiOmsets",
                column: "BentukLahanUsahaId",
                principalTable: "RFBentukLahans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InformasiOmsets_RFSatuanLuass_LuasLahanUsahaId",
                table: "InformasiOmsets",
                column: "LuasLahanUsahaId",
                principalTable: "RFSatuanLuass",
                principalColumn: "Id");
        }
    }
}
