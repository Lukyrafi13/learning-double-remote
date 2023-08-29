using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaSiklusAttrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BerjalanLebihEnamBulan",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DibiayaiSesuaiTarget",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KolektibilitasLancar",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LokasiUsahaDalamRadius",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MilikCalonDebitur",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PendapatanBersihUsahaLainnya",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFKepemilikanUsahaId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFLamaUsahaLainId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TidakMasukDaftarHitam",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFKepemilikanUsahaId",
                table: "Analisas",
                column: "RFKepemilikanUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFLamaUsahaLainId",
                table: "Analisas",
                column: "RFLamaUsahaLainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFKepemilikanUsaha_RFKepemilikanUsahaId",
                table: "Analisas",
                column: "RFKepemilikanUsahaId",
                principalTable: "RFKepemilikanUsaha",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFLamaUsahaLain_RFLamaUsahaLainId",
                table: "Analisas",
                column: "RFLamaUsahaLainId",
                principalTable: "RFLamaUsahaLain",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFKepemilikanUsaha_RFKepemilikanUsahaId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFLamaUsahaLain_RFLamaUsahaLainId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFKepemilikanUsahaId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFLamaUsahaLainId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BerjalanLebihEnamBulan",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "DibiayaiSesuaiTarget",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "KolektibilitasLancar",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "LokasiUsahaDalamRadius",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MilikCalonDebitur",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "PendapatanBersihUsahaLainnya",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFKepemilikanUsahaId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFLamaUsahaLainId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "TidakMasukDaftarHitam",
                table: "Analisas");
        }
    }
}
