using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IDEEntityInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AplikasiId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RFSCOHutangPihakLainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOLokTempatUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOHubunganPerbankanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NamaCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomorKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerlakuSampaiDengan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SiklusUsaha = table.Column<bool>(type: "bit", nullable: true),
                    NomorTelpon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTelpKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaIbuKandung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LamaTingggal = table.Column<int>(type: "int", nullable: true),
                    JumlahTanggungan = table.Column<int>(type: "int", nullable: true),
                    NoKTPKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RWKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorAktaNikah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalAktaNikah = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PembuatAktaNikah = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaLengkapPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTPPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWPPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahirPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahirPasangan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlamatSamaDenganDebitur = table.Column<bool>(type: "bit", nullable: false),
                    AlamatPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RWPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiPasangan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorAktaPendirian = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalAktaPendirian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomorPendaftaran = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalSK = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerubahanAktaTerakhir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalAkta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomorSIUP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalSIUP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomorTDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalTDP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalJatuhTempoTDP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomorSKDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalSKDP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalJatuhTempoSK = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SumberData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebiturId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOReputasiTempatTinggalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOTingkatKebutuhanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOCaraTransaksiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOPengelolaKeuanganId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOMutasiPerBulanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCORiwayatKreditBJBId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOScoringAgunanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSCOSaldoRekRataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeId = table.Column<int>(type: "int", nullable: true),
                    RFEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeKontakDaruratId = table.Column<int>(type: "int", nullable: true),
                    RFJobPasanganId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodePasanganId = table.Column<int>(type: "int", nullable: true),
                    RfBranchesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apps_Debiturs_DebiturId",
                        column: x => x.DebiturId,
                        principalTable: "Debiturs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RfBranches_RfBranchesId",
                        column: x => x.RfBranchesId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Apps_RFEDUCATION_RFEducationId",
                        column: x => x.RFEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFJOB_RFJobId",
                        column: x => x.RFJobId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFJOB_RFJobPasanganId",
                        column: x => x.RFJobPasanganId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFMARITALs_RFMaritalId",
                        column: x => x.RFMaritalId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFOwnerCategories_RFOwnerCategoryId",
                        column: x => x.RFOwnerCategoryId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFProducts_RFProductId",
                        column: x => x.RFProductId,
                        principalTable: "RFProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOCARATRANSAKSI_RFSCOCaraTransaksiId",
                        column: x => x.RFSCOCaraTransaksiId,
                        principalTable: "RFSCOCARATRANSAKSI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOHUBUNGANPERBANKAN_RFSCOHubunganPerbankanId",
                        column: x => x.RFSCOHubunganPerbankanId,
                        principalTable: "RFSCOHUBUNGANPERBANKAN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOHUTANGPIHAKLAIN_RFSCOHutangPihakLainId",
                        column: x => x.RFSCOHutangPihakLainId,
                        principalTable: "RFSCOHUTANGPIHAKLAIN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOLOKTEMPATUSAHA_RFSCOLokTempatUsahaId",
                        column: x => x.RFSCOLokTempatUsahaId,
                        principalTable: "RFSCOLOKTEMPATUSAHA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOMUTASIPERBULAN_RFSCOMutasiPerBulanId",
                        column: x => x.RFSCOMutasiPerBulanId,
                        principalTable: "RFSCOMUTASIPERBULAN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOPENGELOLAKEUANGAN_RFSCOPengelolaKeuanganId",
                        column: x => x.RFSCOPengelolaKeuanganId,
                        principalTable: "RFSCOPENGELOLAKEUANGAN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOREPUTASITEMPATTINGGAL_RFSCOReputasiTempatTinggalId",
                        column: x => x.RFSCOReputasiTempatTinggalId,
                        principalTable: "RFSCOREPUTASITEMPATTINGGAL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCORiwayatKreditBJBs_RFSCORiwayatKreditBJBId",
                        column: x => x.RFSCORiwayatKreditBJBId,
                        principalTable: "RFSCORiwayatKreditBJBs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOSALDOREKRATA_RFSCOSaldoRekRataId",
                        column: x => x.RFSCOSaldoRekRataId,
                        principalTable: "RFSCOSALDOREKRATA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOSCORINGAGUNAN_RFSCOScoringAgunanId",
                        column: x => x.RFSCOScoringAgunanId,
                        principalTable: "RFSCOSCORINGAGUNAN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFSCOTINGKATKEBUTUHAN_RFSCOTingkatKebutuhanId",
                        column: x => x.RFSCOTingkatKebutuhanId,
                        principalTable: "RFSCOTINGKATKEBUTUHAN",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFZipCodes_RFZipCodeId",
                        column: x => x.RFZipCodeId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFZipCodes_RFZipCodeKontakDaruratId",
                        column: x => x.RFZipCodeKontakDaruratId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apps_RFZipCodes_RFZipCodePasanganId",
                        column: x => x.RFZipCodePasanganId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppKeyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Jabatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasaBerlakuKTP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeumurHidup = table.Column<bool>(type: "bit", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AppKeyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppKeyPersons_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppKeyPersons_RFEDUCATION_RFEducationId",
                        column: x => x.RFEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppKeyPersons_RFMARITALs_RFMaritalId",
                        column: x => x.RFMaritalId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppKeyPersons_RFZipCodes_RFZipCodeId",
                        column: x => x.RFZipCodeId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppKeyPersons_AppId",
                table: "AppKeyPersons",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppKeyPersons_RFEducationId",
                table: "AppKeyPersons",
                column: "RFEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppKeyPersons_RFMaritalId",
                table: "AppKeyPersons",
                column: "RFMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_AppKeyPersons_RFZipCodeId",
                table: "AppKeyPersons",
                column: "RFZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_DebiturId",
                table: "Apps",
                column: "DebiturId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_ProspectId",
                table: "Apps",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RfBranchesId",
                table: "Apps",
                column: "RfBranchesId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFEducationId",
                table: "Apps",
                column: "RFEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFJobId",
                table: "Apps",
                column: "RFJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFJobPasanganId",
                table: "Apps",
                column: "RFJobPasanganId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFMaritalId",
                table: "Apps",
                column: "RFMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFOwnerCategoryId",
                table: "Apps",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFProductId",
                table: "Apps",
                column: "RFProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOCaraTransaksiId",
                table: "Apps",
                column: "RFSCOCaraTransaksiId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOHubunganPerbankanId",
                table: "Apps",
                column: "RFSCOHubunganPerbankanId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOHutangPihakLainId",
                table: "Apps",
                column: "RFSCOHutangPihakLainId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOLokTempatUsahaId",
                table: "Apps",
                column: "RFSCOLokTempatUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOMutasiPerBulanId",
                table: "Apps",
                column: "RFSCOMutasiPerBulanId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOPengelolaKeuanganId",
                table: "Apps",
                column: "RFSCOPengelolaKeuanganId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOReputasiTempatTinggalId",
                table: "Apps",
                column: "RFSCOReputasiTempatTinggalId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCORiwayatKreditBJBId",
                table: "Apps",
                column: "RFSCORiwayatKreditBJBId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOSaldoRekRataId",
                table: "Apps",
                column: "RFSCOSaldoRekRataId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOScoringAgunanId",
                table: "Apps",
                column: "RFSCOScoringAgunanId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFSCOTingkatKebutuhanId",
                table: "Apps",
                column: "RFSCOTingkatKebutuhanId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFZipCodeId",
                table: "Apps",
                column: "RFZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFZipCodeKontakDaruratId",
                table: "Apps",
                column: "RFZipCodeKontakDaruratId");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_RFZipCodePasanganId",
                table: "Apps",
                column: "RFZipCodePasanganId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppKeyPersons");

            migrationBuilder.DropTable(
                name: "Apps");
        }
    }
}
