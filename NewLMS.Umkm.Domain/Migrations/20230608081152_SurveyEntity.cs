using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SurveyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TanggalSurvey = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NamaSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaVerifikator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrangDitemui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTelpPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LamaTahunBerdiri = table.Column<int>(type: "int", nullable: true),
                    LamaBulanBerdiri = table.Column<int>(type: "int", nullable: true),
                    JumlahKaryawan = table.Column<int>(type: "int", nullable: true),
                    JumlahCabang = table.Column<int>(type: "int", nullable: true),
                    AlamatSamaDenganDebitur = table.Column<bool>(type: "bit", nullable: true),
                    AlamatSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinsiSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanSurveyor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesimpulanHasil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OmsetWawancara = table.Column<double>(type: "float", nullable: true),
                    OmsetObservasi = table.Column<double>(type: "float", nullable: true),
                    OmsetData = table.Column<double>(type: "float", nullable: true),
                    OmsetDiambil = table.Column<double>(type: "float", nullable: true),
                    PenjualanTahunan = table.Column<double>(type: "float", nullable: true),
                    KekayaanBersihDiluarTempatUsaha = table.Column<double>(type: "float", nullable: true),
                    DasarPertimbangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPMWawancara = table.Column<double>(type: "float", nullable: true),
                    GPMObservasi = table.Column<double>(type: "float", nullable: true),
                    GPMTerendah = table.Column<double>(type: "float", nullable: true),
                    HPP = table.Column<double>(type: "float", nullable: true),
                    BiayaTenagaKerja = table.Column<double>(type: "float", nullable: true),
                    BiayaListrik = table.Column<double>(type: "float", nullable: true),
                    BiayaAir = table.Column<double>(type: "float", nullable: true),
                    BiayaTelpon = table.Column<double>(type: "float", nullable: true),
                    BiayaHP = table.Column<double>(type: "float", nullable: true),
                    BiayaOperasional = table.Column<double>(type: "float", nullable: true),
                    BiayaRumahTanggaWawancara = table.Column<double>(type: "float", nullable: true),
                    BiayaRumahTanggaHasilVerifikasi = table.Column<double>(type: "float", nullable: true),
                    BiayaRumahTanggaKeseluruhan20 = table.Column<double>(type: "float", nullable: true),
                    BiayaRumahTanggaTertinggi = table.Column<double>(type: "float", nullable: true),
                    ModalKerjaStokBarang = table.Column<double>(type: "float", nullable: true),
                    ModalKerjaPiutang = table.Column<double>(type: "float", nullable: true),
                    ModalKerjaHutang = table.Column<double>(type: "float", nullable: true),
                    SesuaiTargetMarket = table.Column<bool>(type: "bit", nullable: true),
                    MasukRadiusCabang = table.Column<bool>(type: "bit", nullable: true),
                    UsahaMilikSendiri = table.Column<bool>(type: "bit", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFRelationSurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFKepemilikanTempatUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerOTSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFBusinessType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFBidangUsahaKUR = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LamaUsahaLain = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppId",
                table: "Surveys",
                column: "AppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
