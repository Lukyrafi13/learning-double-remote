using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppAgunanRefineField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlamatAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HubunganLainnya",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IzinMendirikanBangunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LetakTanah",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LuasBangunan",
                table: "AppAgunans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LuasTanah",
                table: "AppAgunans",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPWPPemilik",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaLokasiPasar",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPemegangHak",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NilaiNJOPPBB",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoObjekPajak",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoSuratUkur",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorMesin",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRangka",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PekerjaanPemilik",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenerbitDokumen",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeringkatHT",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiAgunan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFMaritalId",
                table: "AppAgunans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFVehModelId",
                table: "AppAgunans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeAgunanId",
                table: "AppAgunans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalLahirPemilik",
                table: "AppAgunans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalSuratUkur",
                table: "AppAgunans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempatLahirPemilik",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFMaritalId",
                table: "AppAgunans",
                column: "RFMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFVehModelId",
                table: "AppAgunans",
                column: "RFVehModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFZipCodeAgunanId",
                table: "AppAgunans",
                column: "RFZipCodeAgunanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFMARITALs_RFMaritalId",
                table: "AppAgunans",
                column: "RFMaritalId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFVehModels_RFVehModelId",
                table: "AppAgunans",
                column: "RFVehModelId",
                principalTable: "RFVehModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFZipCodes_RFZipCodeAgunanId",
                table: "AppAgunans",
                column: "RFZipCodeAgunanId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFMARITALs_RFMaritalId",
                table: "AppAgunans");

            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFVehModels_RFVehModelId",
                table: "AppAgunans");

            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFZipCodes_RFZipCodeAgunanId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFMaritalId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFVehModelId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFZipCodeAgunanId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "AlamatAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "HubunganLainnya",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "IzinMendirikanBangunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KecamatanAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KelurahanAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "LetakTanah",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "LuasBangunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "LuasTanah",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NPWPPemilik",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NamaLokasiPasar",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NamaPemegangHak",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NilaiNJOPPBB",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NoObjekPajak",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NoSuratUkur",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NomorMesin",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NomorRangka",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PekerjaanPemilik",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PenerbitDokumen",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PeringkatHT",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PropinsiAgunan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFMaritalId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFVehModelId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFZipCodeAgunanId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "TanggalLahirPemilik",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "TanggalSuratUkur",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "TempatLahirPemilik",
                table: "AppAgunans");
        }
    }
}
