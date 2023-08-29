using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectAddAttrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlamatLengkapUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlamatUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorKTP",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiUsaha",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJenisUsahaId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFKelompokUsahaId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeUsahaId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalLahir",
                table: "Prospects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempatLahir",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFJenisUsahaId",
                table: "Prospects",
                column: "RFJenisUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFKelompokUsahaId",
                table: "Prospects",
                column: "RFKelompokUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFZipCodeUsahaId",
                table: "Prospects",
                column: "RFZipCodeUsahaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFJenisUsahas_RFJenisUsahaId",
                table: "Prospects",
                column: "RFJenisUsahaId",
                principalTable: "RFJenisUsahas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFKelompokUsahas_RFKelompokUsahaId",
                table: "Prospects",
                column: "RFKelompokUsahaId",
                principalTable: "RFKelompokUsahas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeUsahaId",
                table: "Prospects",
                column: "RFZipCodeUsahaId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFJenisUsahas_RFJenisUsahaId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFKelompokUsahas_RFKelompokUsahaId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeUsahaId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFJenisUsahaId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFKelompokUsahaId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFZipCodeUsahaId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "AlamatLengkapUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "AlamatUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KecamatanUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KelurahanUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "NamaUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "NomorKTP",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "PropinsiUsaha",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFJenisUsahaId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFKelompokUsahaId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFZipCodeUsahaId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "TanggalLahir",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "TempatLahir",
                table: "Prospects");
        }
    }
}
