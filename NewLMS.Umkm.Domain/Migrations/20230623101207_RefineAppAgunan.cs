using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RefineAppAgunan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlamatPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BerlakuSampaiDenganPasangan",
                table: "AppAgunans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPWPPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorKTPPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PekerjaanPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodePasanganId",
                table: "AppAgunans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SeumurHidupPasangan",
                table: "AppAgunans",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalLahirPasangan",
                table: "AppAgunans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempatLahirPasangan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFZipCodePasanganId",
                table: "AppAgunans",
                column: "RFZipCodePasanganId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFZipCodes_RFZipCodePasanganId",
                table: "AppAgunans",
                column: "RFZipCodePasanganId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFZipCodes_RFZipCodePasanganId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFZipCodePasanganId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "AlamatPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "BerlakuSampaiDenganPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KecamatanPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "KelurahanPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NPWPPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NamaPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "NomorKTPPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PekerjaanPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "PropinsiPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFZipCodePasanganId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "SeumurHidupPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "TanggalLahirPasangan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "TempatLahirPasangan",
                table: "AppAgunans");
        }
    }
}
