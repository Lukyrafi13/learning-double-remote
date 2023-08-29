using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RefineSPPKEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountOfficeCode",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtasNamaBunga",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtasNamaDebitur",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtasNamaPencairan",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtasNamaPokok",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BiayaAdmin",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatatanLainnya",
                table: "SPPKs",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatMKK1",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatMKK2",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatMKK3",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatMKK4",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatMKK5",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatSKK1",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatSKK2",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatSPPK1",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamaPejabatSPPK2",
                table: "SPPKs",
                type: "nvarchar(max)",
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
                name: "NoMKK",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoSKK",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoSPPK",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NominalYangDicairkan",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorCIFBunga",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorCIFDebitur",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorCIFPencairan",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorCIFPokok",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningEksternalBunga",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningEksternalDebitur",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningEksternalPencairan",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningEksternalPokok",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningInternalBunga",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningInternalDebitur",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningInternalPencairan",
                table: "SPPKs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomorRekeningInternalPokok",
                table: "SPPKs",
                type: "nvarchar(max)",
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
                name: "RFJabatanMKK1Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanMKK2Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanMKK3Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanMKK4Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanMKK5Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanSKK1Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanSKK2Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanSPPK1Id",
                table: "SPPKs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJabatanSPPK2Id",
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

            migrationBuilder.AddColumn<bool>(
                name: "SPPKDisetujuiNasabah",
                table: "SPPKs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalMKK",
                table: "SPPKs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalSKK",
                table: "SPPKs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalSPPK",
                table: "SPPKs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalBiayaAsuransi",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalBiayaBiaya",
                table: "SPPKs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPlafond",
                table: "SPPKs",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountOfficeCode",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "AtasNamaBunga",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "AtasNamaDebitur",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "AtasNamaPencairan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "AtasNamaPokok",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "BiayaAdmin",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "CatatanLainnya",
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
                name: "NamaPejabatMKK1",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatMKK2",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatMKK3",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatMKK4",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatMKK5",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatSKK1",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatSKK2",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatSPPK1",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NamaPejabatSPPK2",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NilaiPertanggungan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NilaiProvinsi",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NoMKK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NoSKK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NoSPPK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NominalYangDicairkan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorCIFBunga",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorCIFDebitur",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorCIFPencairan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorCIFPokok",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningEksternalBunga",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningEksternalDebitur",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningEksternalPencairan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningEksternalPokok",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningInternalBunga",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningInternalDebitur",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningInternalPencairan",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "NomorRekeningInternalPokok",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFCaraPenarikanId",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanMKK1Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanMKK2Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanMKK3Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanMKK4Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanMKK5Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanSKK1Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanSKK2Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanSPPK1Id",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "RFJabatanSPPK2Id",
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
                name: "SPPKDisetujuiNasabah",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TanggalMKK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TanggalSKK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TanggalSPPK",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TotalBiayaAsuransi",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TotalBiayaBiaya",
                table: "SPPKs");

            migrationBuilder.DropColumn(
                name: "TotalPlafond",
                table: "SPPKs");
        }
    }
}
