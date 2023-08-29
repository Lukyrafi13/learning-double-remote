using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaComplianceSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BMPK",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BMPKBUMN",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BOKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BOKorporasi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BOMikro",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BONonKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BORitel",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPDKKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPDKKorporasi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPDKMikro",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPDKNonKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HPDKRitel",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Inhouse",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MKKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MKKorporasi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MKMikro",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MKNonKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MKRitel",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ModalBank",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ModalInti",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PenyediaanDanaBesar",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodeBMPK",
                table: "Analisas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodeSBDK",
                table: "Analisas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCSBPDetailBenturanId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCSBPDetailHubunganId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCSBPDetailPengecekanId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFCSBPDetailProfileId",
                table: "Analisas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKKorporasi",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKMikro",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKNonKPR",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SBDKRitel",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalPengecekan",
                table: "Analisas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFCSBPDetailBenturanId",
                table: "Analisas",
                column: "RFCSBPDetailBenturanId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFCSBPDetailHubunganId",
                table: "Analisas",
                column: "RFCSBPDetailHubunganId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFCSBPDetailPengecekanId",
                table: "Analisas",
                column: "RFCSBPDetailPengecekanId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFCSBPDetailProfileId",
                table: "Analisas",
                column: "RFCSBPDetailProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailBenturanId",
                table: "Analisas",
                column: "RFCSBPDetailBenturanId",
                principalTable: "RFCSBPDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailHubunganId",
                table: "Analisas",
                column: "RFCSBPDetailHubunganId",
                principalTable: "RFCSBPDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailPengecekanId",
                table: "Analisas",
                column: "RFCSBPDetailPengecekanId",
                principalTable: "RFCSBPDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailProfileId",
                table: "Analisas",
                column: "RFCSBPDetailProfileId",
                principalTable: "RFCSBPDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailBenturanId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailHubunganId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailPengecekanId",
                table: "Analisas");

            migrationBuilder.DropForeignKey(
                name: "FK_Analisas_RFCSBPDetails_RFCSBPDetailProfileId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFCSBPDetailBenturanId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFCSBPDetailHubunganId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFCSBPDetailPengecekanId",
                table: "Analisas");

            migrationBuilder.DropIndex(
                name: "IX_Analisas_RFCSBPDetailProfileId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BMPK",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BMPKBUMN",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BOKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BOKorporasi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BOMikro",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BONonKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "BORitel",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "HPDKKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "HPDKKorporasi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "HPDKMikro",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "HPDKNonKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "HPDKRitel",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "Inhouse",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MKKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MKKorporasi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MKMikro",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MKNonKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "MKRitel",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "ModalBank",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "ModalInti",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "PenyediaanDanaBesar",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "PeriodeBMPK",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "PeriodeSBDK",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFCSBPDetailBenturanId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFCSBPDetailHubunganId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFCSBPDetailPengecekanId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "RFCSBPDetailProfileId",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKKorporasi",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKMikro",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKNonKPR",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "SBDKRitel",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "TanggalPengecekan",
                table: "Analisas");
        }
    }
}
