using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SIKPBookingEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIKPBookings");

            migrationBuilder.CreateTable(
                name: "SIKPCalonDebiturs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoCIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDebitur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalMulaiUsaha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlamatUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IzinUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalUsaha = table.Column<double>(type: "float", nullable: true),
                    JumlahKredit = table.Column<double>(type: "float", nullable: true),
                    NoHP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agunan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JumlahPekerja = table.Column<int>(type: "int", nullable: true),
                    StatusSubsidi = table.Column<bool>(type: "bit", nullable: true),
                    SubsidiSebelumnya = table.Column<double>(type: "float", nullable: true),
                    NoRegistrasiSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDebiturSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalLahirSIKP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlamatSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalMulaiUsahaSIKP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AlamatUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IzinUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalUsahaSIKP = table.Column<double>(type: "float", nullable: true),
                    JumlahKreditSIKP = table.Column<double>(type: "float", nullable: true),
                    NoHPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgunanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JumlahPekerjaSIKP = table.Column<int>(type: "int", nullable: true),
                    StatusSubsidiSIKP = table.Column<bool>(type: "bit", nullable: true),
                    SubsidiSebelumnyaSIKP = table.Column<double>(type: "float", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeId = table.Column<int>(type: "int", nullable: true),
                    RFZipCodeUsahaId = table.Column<int>(type: "int", nullable: true),
                    RFOwnerCategoryUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFGenderSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFEducationSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJobSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeSIKPId = table.Column<int>(type: "int", nullable: true),
                    RFZipCodeUsahaSIKPId = table.Column<int>(type: "int", nullable: true),
                    RFOwnerCategoryUsahaSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SIKPCalonDebiturs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFEDUCATION_RFEducationId",
                        column: x => x.RFEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFEDUCATION_RFEducationSIKPId",
                        column: x => x.RFEducationSIKPId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFGenders_RFGenderId",
                        column: x => x.RFGenderId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFGenders_RFGenderSIKPId",
                        column: x => x.RFGenderSIKPId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFJOB_RFJobId",
                        column: x => x.RFJobId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFJOB_RFJobSIKPId",
                        column: x => x.RFJobSIKPId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFMARITALs_RFMaritalId",
                        column: x => x.RFMaritalId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFMARITALs_RFMaritalSIKPId",
                        column: x => x.RFMaritalSIKPId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryId",
                        column: x => x.RFOwnerCategoryId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaId",
                        column: x => x.RFOwnerCategoryUsahaId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaSIKPId",
                        column: x => x.RFOwnerCategoryUsahaSIKPId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFSectorLBU1s_RFSectorLBU1Code",
                        column: x => x.RFSectorLBU1Code,
                        principalTable: "RFSectorLBU1s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFSectorLBU2s_RFSectorLBU2Code",
                        column: x => x.RFSectorLBU2Code,
                        principalTable: "RFSectorLBU2s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFSectorLBU3s_RFSectorLBU3Code",
                        column: x => x.RFSectorLBU3Code,
                        principalTable: "RFSectorLBU3s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFZipCodes_RFZipCodeId",
                        column: x => x.RFZipCodeId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFZipCodes_RFZipCodeSIKPId",
                        column: x => x.RFZipCodeSIKPId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFZipCodes_RFZipCodeUsahaId",
                        column: x => x.RFZipCodeUsahaId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPCalonDebiturs_RFZipCodes_RFZipCodeUsahaSIKPId",
                        column: x => x.RFZipCodeUsahaSIKPId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_AppId",
                table: "SIKPCalonDebiturs",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFEducationId",
                table: "SIKPCalonDebiturs",
                column: "RFEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFEducationSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFEducationSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFGenderId",
                table: "SIKPCalonDebiturs",
                column: "RFGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFGenderSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFGenderSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFJobId",
                table: "SIKPCalonDebiturs",
                column: "RFJobId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFJobSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFJobSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFMaritalId",
                table: "SIKPCalonDebiturs",
                column: "RFMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFMaritalSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFMaritalSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFOwnerCategoryId",
                table: "SIKPCalonDebiturs",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaId",
                table: "SIKPCalonDebiturs",
                column: "RFOwnerCategoryUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFOwnerCategoryUsahaSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFSectorLBU1Code",
                table: "SIKPCalonDebiturs",
                column: "RFSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFSectorLBU2Code",
                table: "SIKPCalonDebiturs",
                column: "RFSectorLBU2Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFSectorLBU3Code",
                table: "SIKPCalonDebiturs",
                column: "RFSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFZipCodeId",
                table: "SIKPCalonDebiturs",
                column: "RFZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFZipCodeSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFZipCodeSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFZipCodeUsahaId",
                table: "SIKPCalonDebiturs",
                column: "RFZipCodeUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPCalonDebiturs_RFZipCodeUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFZipCodeUsahaSIKPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIKPCalonDebiturs");

            migrationBuilder.CreateTable(
                name: "SIKPBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFEducationSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFGenderSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJobSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFMaritalSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerCategoryUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFOwnerCategoryUsahaSIKPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFZipCodeId = table.Column<int>(type: "int", nullable: true),
                    RFZipCodeSIKPId = table.Column<int>(type: "int", nullable: true),
                    RFZipCodeUsahaId = table.Column<int>(type: "int", nullable: true),
                    RFZipCodeUsahaSIKPId = table.Column<int>(type: "int", nullable: true),
                    Agunan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgunanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlamatUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IzinUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IzinUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JumlahKredit = table.Column<double>(type: "float", nullable: true),
                    JumlahKreditSIKP = table.Column<double>(type: "float", nullable: true),
                    JumlahPekerja = table.Column<int>(type: "int", nullable: true),
                    JumlahPekerjaSIKP = table.Column<int>(type: "int", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKotaUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KecamatanUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KelurahanUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModalUsaha = table.Column<double>(type: "float", nullable: true),
                    ModalUsahaSIKP = table.Column<double>(type: "float", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDebitur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDebiturSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoCIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoHP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoHPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoKTPSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoRegistrasiSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropinsiUsahaSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSubsidi = table.Column<bool>(type: "bit", nullable: true),
                    StatusSubsidiSIKP = table.Column<bool>(type: "bit", nullable: true),
                    SubsidiSebelumnya = table.Column<double>(type: "float", nullable: true),
                    SubsidiSebelumnyaSIKP = table.Column<double>(type: "float", nullable: true),
                    TanggalLahir = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalLahirSIKP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalMulaiUsaha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalMulaiUsahaSIKP = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIKPBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPBookings_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFEDUCATION_RFEducationId",
                        column: x => x.RFEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFEDUCATION_RFEducationSIKPId",
                        column: x => x.RFEducationSIKPId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFGenders_RFGenderId",
                        column: x => x.RFGenderId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFGenders_RFGenderSIKPId",
                        column: x => x.RFGenderSIKPId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFJOB_RFJobId",
                        column: x => x.RFJobId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFJOB_RFJobSIKPId",
                        column: x => x.RFJobSIKPId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFMARITALs_RFMaritalId",
                        column: x => x.RFMaritalId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFMARITALs_RFMaritalSIKPId",
                        column: x => x.RFMaritalSIKPId,
                        principalTable: "RFMARITALs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFOwnerCategories_RFOwnerCategoryId",
                        column: x => x.RFOwnerCategoryId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFOwnerCategories_RFOwnerCategoryUsahaId",
                        column: x => x.RFOwnerCategoryUsahaId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFOwnerCategories_RFOwnerCategoryUsahaSIKPId",
                        column: x => x.RFOwnerCategoryUsahaSIKPId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFSectorLBU1s_RFSectorLBU1Code",
                        column: x => x.RFSectorLBU1Code,
                        principalTable: "RFSectorLBU1s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFSectorLBU2s_RFSectorLBU2Code",
                        column: x => x.RFSectorLBU2Code,
                        principalTable: "RFSectorLBU2s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFSectorLBU3s_RFSectorLBU3Code",
                        column: x => x.RFSectorLBU3Code,
                        principalTable: "RFSectorLBU3s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFZipCodes_RFZipCodeId",
                        column: x => x.RFZipCodeId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFZipCodes_RFZipCodeSIKPId",
                        column: x => x.RFZipCodeSIKPId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFZipCodes_RFZipCodeUsahaId",
                        column: x => x.RFZipCodeUsahaId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SIKPBookings_RFZipCodes_RFZipCodeUsahaSIKPId",
                        column: x => x.RFZipCodeUsahaSIKPId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_AppId",
                table: "SIKPBookings",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFEducationId",
                table: "SIKPBookings",
                column: "RFEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFEducationSIKPId",
                table: "SIKPBookings",
                column: "RFEducationSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFGenderId",
                table: "SIKPBookings",
                column: "RFGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFGenderSIKPId",
                table: "SIKPBookings",
                column: "RFGenderSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFJobId",
                table: "SIKPBookings",
                column: "RFJobId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFJobSIKPId",
                table: "SIKPBookings",
                column: "RFJobSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFMaritalId",
                table: "SIKPBookings",
                column: "RFMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFMaritalSIKPId",
                table: "SIKPBookings",
                column: "RFMaritalSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFOwnerCategoryId",
                table: "SIKPBookings",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFOwnerCategoryUsahaId",
                table: "SIKPBookings",
                column: "RFOwnerCategoryUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFOwnerCategoryUsahaSIKPId",
                table: "SIKPBookings",
                column: "RFOwnerCategoryUsahaSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFSectorLBU1Code",
                table: "SIKPBookings",
                column: "RFSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFSectorLBU2Code",
                table: "SIKPBookings",
                column: "RFSectorLBU2Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFSectorLBU3Code",
                table: "SIKPBookings",
                column: "RFSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFZipCodeId",
                table: "SIKPBookings",
                column: "RFZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFZipCodeSIKPId",
                table: "SIKPBookings",
                column: "RFZipCodeSIKPId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFZipCodeUsahaId",
                table: "SIKPBookings",
                column: "RFZipCodeUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPBookings_RFZipCodeUsahaSIKPId",
                table: "SIKPBookings",
                column: "RFZipCodeUsahaSIKPId");
        }
    }
}
