using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RevampProspectEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFOwnerCategories_RFOwnerCategoryId",
                table: "Debiturs");

            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFProducts_RFProductId",
                table: "Debiturs");

            migrationBuilder.DropForeignKey(
                name: "FK_Debiturs_RFStatusTargets_RFStatusId",
                table: "Debiturs");

            migrationBuilder.DropIndex(
                name: "IX_Debiturs_RFOwnerCategoryId",
                table: "Debiturs");

            migrationBuilder.DropIndex(
                name: "IX_Debiturs_RFProductId",
                table: "Debiturs");

            migrationBuilder.DropIndex(
                name: "IX_Debiturs_RFStatusId",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "Alamat",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "Alasan",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "Cabang",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "PerkiraanPengajuan",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "RFOwnerCategoryId",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "RFProductId",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "RFStatusId",
                table: "Debiturs");

            migrationBuilder.RenameColumn(
                name: "TanggalProspect",
                table: "Debiturs",
                newName: "TanggalLahir");

            migrationBuilder.RenameColumn(
                name: "SumberData",
                table: "Debiturs",
                newName: "TempatLahir");

            migrationBuilder.RenameColumn(
                name: "SubSubSektorEkonomi",
                table: "Debiturs",
                newName: "PropinsiTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "SubSektorEkonomi",
                table: "Debiturs",
                newName: "NomorHP");

            migrationBuilder.RenameColumn(
                name: "StatusPerusahaan",
                table: "Debiturs",
                newName: "NoTelpDapatDihubungi");

            migrationBuilder.RenameColumn(
                name: "SektorEkonomi",
                table: "Debiturs",
                newName: "NamaLengkap");

            migrationBuilder.RenameColumn(
                name: "NamaTengahCustomer",
                table: "Debiturs",
                newName: "KodePosTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "NamaDepanCustomer",
                table: "Debiturs",
                newName: "KelurahanTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "NamaCustomer",
                table: "Debiturs",
                newName: "KecamatanTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "NamaBelakangCustomer",
                table: "Debiturs",
                newName: "KabupatenKotaTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "NamaAO",
                table: "Debiturs",
                newName: "AlamatTempatTinggal");

            migrationBuilder.RenameColumn(
                name: "JenisPermohonanKredit",
                table: "Debiturs",
                newName: "AlamatKTP");

            migrationBuilder.AddColumn<bool>(
                name: "AlamatSesuaiKTP",
                table: "Debiturs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomorKTP",
                table: "Debiturs",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProspectId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NamaCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDepanCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaTengahCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaBelakangCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusPerusahaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTelpon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cabang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisPermohonanKredit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSubSektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alasan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerkiraanPengajuan = table.Column<double>(type: "float", nullable: false),
                    TanggalProspect = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumberData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prospects_RFGenders_RFGenderId",
                        column: x => x.RFGenderId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RFOwnerCategories_RFOwnerCategoryId",
                        column: x => x.RFOwnerCategoryId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RFProducts_RFProductId",
                        column: x => x.RFProductId,
                        principalTable: "RFProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_RFStatusTargets_RFStatusId",
                        column: x => x.RFStatusId,
                        principalTable: "RFStatusTargets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFGenderId",
                table: "Prospects",
                column: "RFGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFOwnerCategoryId",
                table: "Prospects",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFProductId",
                table: "Prospects",
                column: "RFProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFStatusId",
                table: "Prospects",
                column: "RFStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropColumn(
                name: "AlamatSesuaiKTP",
                table: "Debiturs");

            migrationBuilder.DropColumn(
                name: "NomorKTP",
                table: "Debiturs");

            migrationBuilder.RenameColumn(
                name: "TempatLahir",
                table: "Debiturs",
                newName: "SumberData");

            migrationBuilder.RenameColumn(
                name: "TanggalLahir",
                table: "Debiturs",
                newName: "TanggalProspect");

            migrationBuilder.RenameColumn(
                name: "PropinsiTempatTinggal",
                table: "Debiturs",
                newName: "SubSubSektorEkonomi");

            migrationBuilder.RenameColumn(
                name: "NomorHP",
                table: "Debiturs",
                newName: "SubSektorEkonomi");

            migrationBuilder.RenameColumn(
                name: "NoTelpDapatDihubungi",
                table: "Debiturs",
                newName: "StatusPerusahaan");

            migrationBuilder.RenameColumn(
                name: "NamaLengkap",
                table: "Debiturs",
                newName: "SektorEkonomi");

            migrationBuilder.RenameColumn(
                name: "KodePosTempatTinggal",
                table: "Debiturs",
                newName: "NamaTengahCustomer");

            migrationBuilder.RenameColumn(
                name: "KelurahanTempatTinggal",
                table: "Debiturs",
                newName: "NamaDepanCustomer");

            migrationBuilder.RenameColumn(
                name: "KecamatanTempatTinggal",
                table: "Debiturs",
                newName: "NamaCustomer");

            migrationBuilder.RenameColumn(
                name: "KabupatenKotaTempatTinggal",
                table: "Debiturs",
                newName: "NamaBelakangCustomer");

            migrationBuilder.RenameColumn(
                name: "AlamatTempatTinggal",
                table: "Debiturs",
                newName: "NamaAO");

            migrationBuilder.RenameColumn(
                name: "AlamatKTP",
                table: "Debiturs",
                newName: "JenisPermohonanKredit");

            migrationBuilder.AddColumn<string>(
                name: "Alamat",
                table: "Debiturs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alasan",
                table: "Debiturs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cabang",
                table: "Debiturs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PerkiraanPengajuan",
                table: "Debiturs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "RFOwnerCategoryId",
                table: "Debiturs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RFProductId",
                table: "Debiturs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RFStatusId",
                table: "Debiturs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFOwnerCategoryId",
                table: "Debiturs",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFProductId",
                table: "Debiturs",
                column: "RFProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFStatusId",
                table: "Debiturs",
                column: "RFStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFOwnerCategories_RFOwnerCategoryId",
                table: "Debiturs",
                column: "RFOwnerCategoryId",
                principalTable: "RFOwnerCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFProducts_RFProductId",
                table: "Debiturs",
                column: "RFProductId",
                principalTable: "RFProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debiturs_RFStatusTargets_RFStatusId",
                table: "Debiturs",
                column: "RFStatusId",
                principalTable: "RFStatusTargets",
                principalColumn: "Id");
        }
    }
}
