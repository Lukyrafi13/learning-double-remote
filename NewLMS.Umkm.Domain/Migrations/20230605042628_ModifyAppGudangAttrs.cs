using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyAppGudangAttrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JenisBarang",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "JumlahBarangKg",
                table: "Apps",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LokasiGudangPenyimpanan",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaLengkapPengelola",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPemilikResi",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NilaiBarang",
                table: "Apps",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoKTPPengelola",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoResi",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoSeriResiGudang",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TglJatuhTempoResiGudang",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TglLahirPengelola",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TglTerbitResi",
                table: "Apps",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JenisBarang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "JumlahBarangKg",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "LokasiGudangPenyimpanan",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaLengkapPengelola",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaPemilikResi",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NilaiBarang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoKTPPengelola",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoResi",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoSeriResiGudang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TglJatuhTempoResiGudang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TglLahirPengelola",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TglTerbitResi",
                table: "Apps");
        }
    }
}
