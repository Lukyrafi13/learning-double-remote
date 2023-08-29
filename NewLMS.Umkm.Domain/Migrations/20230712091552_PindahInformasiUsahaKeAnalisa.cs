using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PindahInformasiUsahaKeAnalisa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiayaAdmin",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "IsCreditInsurance",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "IsLifeInsurance",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "IsLossInsurance",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NilaiPertanggungan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NilaiProvinsi",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFCaraPenarikanId",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFPengikatanKreditId",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFPolaPengambilanAngsuranId",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFStagesId",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TotalBiayaAsuransi",
                table: "SPPKs");

            migrationBuilder.AddColumn<double>(
                name: "BiayaAdmin",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreditInsurance",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLifeInsurance",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLossInsurance",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NilaiPertanggungan",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NilaiProvinsi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                table: "Analisas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCaraPenarikanId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFPengikatanKreditId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFPolaPengambilanAngsuranId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFStagesId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalBiayaAsuransi",
                table: "Analisas",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BiayaAdmin",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "IsCreditInsurance",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "IsLifeInsurance",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "IsLossInsurance",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "NilaiPertanggungan",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "NilaiProvinsi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFCaraPenarikanId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFPengikatanKreditId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFPolaPengambilanAngsuranId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFStagesId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "TotalBiayaAsuransi",
                table: "Analisas");

            migrationBuilder.AddColumn<double>(
                name: "BiayaAdmin",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCreditInsurance",
                table: "SPPKs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLifeInsurance",
                table: "SPPKs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLossInsurance",
                table: "SPPKs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NilaiPertanggungan",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NilaiProvinsi",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCaraPenarikanId",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFPengikatanKreditId",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFPolaPengambilanAngsuranId",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFStagesId",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalBiayaAsuransi",
                table: "SPPKs",
                type: "float",
                nullable: true);
        }
    }
}
