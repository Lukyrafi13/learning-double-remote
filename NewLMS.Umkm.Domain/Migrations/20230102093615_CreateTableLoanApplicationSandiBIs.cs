using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class CreateTableLoanApplicationSandiBIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "LoanApplicationSandiBIs",
                 columns: table => new
                 {
                     LoanApplicationSandiBIId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                     GolonganDebitur = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     GolonganDebiturLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     GolonganDebiturSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     GolonganKredit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     GolonganPenjamin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisAgunanLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisKredit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisKreditLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisKreditSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisPengguna = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisPenggunaLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisPenggunaSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     JenisSukuBunga = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KategoriDebitur = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KategoriPengukuran = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KategoriPortofolio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KategoriPortofolioLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KeterkaitanBMPK = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     KodePeminjam = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     LembagaPemeringkat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     OrientasiPengguna = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     OrientasiPenggunaLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     OrientasiPenggunaSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     PenerbitAgunan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     PeringkatPenerbitAgunan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     PeringkatPerusahaan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SektorEkonomi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SektorEkonomiLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SektorEkonomiSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SifatAgunanLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SifatKredit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SifatKreditLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SifatKreditSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     StatusDebitur = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SubSektorEkonomiLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SubSubSektorEkonomiLBU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     SumberDana = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                     TipePlafond = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                     table.PrimaryKey("PK_LoanApplicationSandiBIs", x => x.LoanApplicationSandiBIId);
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_LoanApplications_LoanApplicationSandiBIId",
                         column: x => x.LoanApplicationSandiBIId,
                         principalTable: "LoanApplications",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_GolonganDebitur",
                         column: x => x.GolonganDebitur,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_GolonganDebiturLBU",
                         column: x => x.GolonganDebiturLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_GolonganDebiturSID",
                         column: x => x.GolonganDebiturSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_GolonganKredit",
                         column: x => x.GolonganKredit,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_GolonganPenjamin",
                         column: x => x.GolonganPenjamin,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisAgunanLBU",
                         column: x => x.JenisAgunanLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisKredit",
                         column: x => x.JenisKredit,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisKreditLBU",
                         column: x => x.JenisKreditLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisKreditSID",
                         column: x => x.JenisKreditSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisPengguna",
                         column: x => x.JenisPengguna,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisPenggunaLBU",
                         column: x => x.JenisPenggunaLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisPenggunaSID",
                         column: x => x.JenisPenggunaSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_JenisSukuBunga",
                         column: x => x.JenisSukuBunga,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KategoriDebitur",
                         column: x => x.KategoriDebitur,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KategoriPengukuran",
                         column: x => x.KategoriPengukuran,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KategoriPortofolio",
                         column: x => x.KategoriPortofolio,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KategoriPortofolioLBU",
                         column: x => x.KategoriPortofolioLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KeterkaitanBMPK",
                         column: x => x.KeterkaitanBMPK,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_KodePeminjam",
                         column: x => x.KodePeminjam,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_LembagaPemeringkat",
                         column: x => x.LembagaPemeringkat,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_OrientasiPengguna",
                         column: x => x.OrientasiPengguna,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_OrientasiPenggunaLBU",
                         column: x => x.OrientasiPenggunaLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_OrientasiPenggunaSID",
                         column: x => x.OrientasiPenggunaSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_PenerbitAgunan",
                         column: x => x.PenerbitAgunan,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_PeringkatPenerbitAgunan",
                         column: x => x.PeringkatPenerbitAgunan,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_PeringkatPerusahaan",
                         column: x => x.PeringkatPerusahaan,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SektorEkonomi",
                         column: x => x.SektorEkonomi,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SektorEkonomiLBU",
                         column: x => x.SektorEkonomiLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SektorEkonomiSID",
                         column: x => x.SektorEkonomiSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SifatAgunanLBU",
                         column: x => x.SifatAgunanLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SifatKredit",
                         column: x => x.SifatKredit,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SifatKreditLBU",
                         column: x => x.SifatKreditLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SifatKreditSID",
                         column: x => x.SifatKreditSID,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_StatusDebitur",
                         column: x => x.StatusDebitur,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SubSektorEkonomiLBU",
                         column: x => x.SubSektorEkonomiLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SubSubSektorEkonomiLBU",
                         column: x => x.SubSubSektorEkonomiLBU,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_SumberDana",
                         column: x => x.SumberDana,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                     table.ForeignKey(
                         name: "FK_LoanApplicationSandiBIs_RfSandiBIs_TipePlafond",
                         column: x => x.TipePlafond,
                         principalTable: "RfSandiBIs",
                         principalColumn: "RfSandiBIId");
                 });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_GolonganDebitur",
                table: "LoanApplicationSandiBIs",
                column: "GolonganDebitur");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_GolonganDebiturLBU",
                table: "LoanApplicationSandiBIs",
                column: "GolonganDebiturLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_GolonganDebiturSID",
                table: "LoanApplicationSandiBIs",
                column: "GolonganDebiturSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_GolonganKredit",
                table: "LoanApplicationSandiBIs",
                column: "GolonganKredit");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_GolonganPenjamin",
                table: "LoanApplicationSandiBIs",
                column: "GolonganPenjamin");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisAgunanLBU",
                table: "LoanApplicationSandiBIs",
                column: "JenisAgunanLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisKredit",
                table: "LoanApplicationSandiBIs",
                column: "JenisKredit");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisKreditLBU",
                table: "LoanApplicationSandiBIs",
                column: "JenisKreditLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisKreditSID",
                table: "LoanApplicationSandiBIs",
                column: "JenisKreditSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisPengguna",
                table: "LoanApplicationSandiBIs",
                column: "JenisPengguna");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisPenggunaLBU",
                table: "LoanApplicationSandiBIs",
                column: "JenisPenggunaLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisPenggunaSID",
                table: "LoanApplicationSandiBIs",
                column: "JenisPenggunaSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_JenisSukuBunga",
                table: "LoanApplicationSandiBIs",
                column: "JenisSukuBunga");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KategoriDebitur",
                table: "LoanApplicationSandiBIs",
                column: "KategoriDebitur");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KategoriPengukuran",
                table: "LoanApplicationSandiBIs",
                column: "KategoriPengukuran");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KategoriPortofolio",
                table: "LoanApplicationSandiBIs",
                column: "KategoriPortofolio");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KategoriPortofolioLBU",
                table: "LoanApplicationSandiBIs",
                column: "KategoriPortofolioLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KeterkaitanBMPK",
                table: "LoanApplicationSandiBIs",
                column: "KeterkaitanBMPK");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_KodePeminjam",
                table: "LoanApplicationSandiBIs",
                column: "KodePeminjam");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_LembagaPemeringkat",
                table: "LoanApplicationSandiBIs",
                column: "LembagaPemeringkat");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_OrientasiPengguna",
                table: "LoanApplicationSandiBIs",
                column: "OrientasiPengguna");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_OrientasiPenggunaLBU",
                table: "LoanApplicationSandiBIs",
                column: "OrientasiPenggunaLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_OrientasiPenggunaSID",
                table: "LoanApplicationSandiBIs",
                column: "OrientasiPenggunaSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_PenerbitAgunan",
                table: "LoanApplicationSandiBIs",
                column: "PenerbitAgunan");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_PeringkatPenerbitAgunan",
                table: "LoanApplicationSandiBIs",
                column: "PeringkatPenerbitAgunan");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_PeringkatPerusahaan",
                table: "LoanApplicationSandiBIs",
                column: "PeringkatPerusahaan");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SektorEkonomi",
                table: "LoanApplicationSandiBIs",
                column: "SektorEkonomi");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SektorEkonomiLBU",
                table: "LoanApplicationSandiBIs",
                column: "SektorEkonomiLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SektorEkonomiSID",
                table: "LoanApplicationSandiBIs",
                column: "SektorEkonomiSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SifatAgunanLBU",
                table: "LoanApplicationSandiBIs",
                column: "SifatAgunanLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SifatKredit",
                table: "LoanApplicationSandiBIs",
                column: "SifatKredit");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SifatKreditLBU",
                table: "LoanApplicationSandiBIs",
                column: "SifatKreditLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SifatKreditSID",
                table: "LoanApplicationSandiBIs",
                column: "SifatKreditSID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_StatusDebitur",
                table: "LoanApplicationSandiBIs",
                column: "StatusDebitur");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SubSektorEkonomiLBU",
                table: "LoanApplicationSandiBIs",
                column: "SubSektorEkonomiLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SubSubSektorEkonomiLBU",
                table: "LoanApplicationSandiBIs",
                column: "SubSubSektorEkonomiLBU");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_SumberDana",
                table: "LoanApplicationSandiBIs",
                column: "SumberDana");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSandiBIs_TipePlafond",
                table: "LoanApplicationSandiBIs",
                column: "TipePlafond");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationSandiBIs");

            migrationBuilder.DropColumn(
                name: "CoreLoanReference",
                table: "LoanApplications");
        }
    }
}
