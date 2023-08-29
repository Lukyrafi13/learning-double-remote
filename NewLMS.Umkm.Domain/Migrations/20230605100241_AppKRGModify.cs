using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppKRGModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlamatBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlamatKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JabatanBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JabatanKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JenisKomoditas",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JumlahAnggota",
                table: "Apps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LamaUsaha",
                table: "Apps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MasaBerlakuKTPBendahara",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MasaBerlakuKTPKetua",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPWPBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPWPKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaLengkapBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaLengkapKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoKTPBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoKTPKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoTelpBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoTelpKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PemilikBarang",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PendidikanTerakhirBendaharaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFEducationBendaharaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFEducationKetuaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFMaritalBendaharaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFMaritalKetuaId",
                table: "Apps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeBendaharaId",
                table: "Apps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeKetuaId",
                table: "Apps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalLahirBendahara",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalLahirKetua",
                table: "Apps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempatLahirBendahara",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempatLahirKetua",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_PendidikanTerakhirBendaharaId",
                table: "Apps",
                column: "PendidikanTerakhirBendaharaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFEducationKetuaId",
                table: "Apps",
                column: "RFEducationKetuaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFMaritalBendaharaId",
                table: "Apps",
                column: "RFMaritalBendaharaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFMaritalKetuaId",
                table: "Apps",
                column: "RFMaritalKetuaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFZipCodeBendaharaId",
                table: "Apps",
                column: "RFZipCodeBendaharaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFZipCodeKetuaId",
                table: "Apps",
                column: "RFZipCodeKetuaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFEDUCATION_PendidikanTerakhirBendaharaId",
                table: "Apps",
                column: "PendidikanTerakhirBendaharaId",
                principalTable: "RFEDUCATION",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFEDUCATION_RFEducationKetuaId",
                table: "Apps",
                column: "RFEducationKetuaId",
                principalTable: "RFEDUCATION",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFMARITALs_RFMaritalBendaharaId",
                table: "Apps",
                column: "RFMaritalBendaharaId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFMARITALs_RFMaritalKetuaId",
                table: "Apps",
                column: "RFMaritalKetuaId",
                principalTable: "RFMARITALs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFZipCodes_RFZipCodeBendaharaId",
                table: "Apps",
                column: "RFZipCodeBendaharaId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_RFZipCodes_RFZipCodeKetuaId",
                table: "Apps",
                column: "RFZipCodeKetuaId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFEDUCATION_PendidikanTerakhirBendaharaId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFEDUCATION_RFEducationKetuaId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFMARITALs_RFMaritalBendaharaId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFMARITALs_RFMaritalKetuaId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFZipCodes_RFZipCodeBendaharaId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_RFZipCodes_RFZipCodeKetuaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_PendidikanTerakhirBendaharaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFEducationKetuaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFMaritalBendaharaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFMaritalKetuaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFZipCodeBendaharaId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_RFZipCodeKetuaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "AlamatBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "AlamatKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "JabatanBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "JabatanKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "JenisKomoditas",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "JumlahAnggota",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KecamatanBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KecamatanKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KelurahanBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "KelurahanKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "LamaUsaha",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "MasaBerlakuKTPBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "MasaBerlakuKTPKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NPWPBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NPWPKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaLengkapBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NamaLengkapKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoKTPBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoKTPKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoTelpBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "NoTelpKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "PemilikBarang",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "PendidikanTerakhirBendaharaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "PropinsiBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "PropinsiKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFEducationBendaharaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFEducationKetuaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFMaritalBendaharaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFMaritalKetuaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFZipCodeBendaharaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "RFZipCodeKetuaId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TanggalLahirBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TanggalLahirKetua",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TempatLahirBendahara",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "TempatLahirKetua",
                table: "Apps");
        }
    }
}
