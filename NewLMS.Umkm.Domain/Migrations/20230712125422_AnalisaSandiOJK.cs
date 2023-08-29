using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaSandiOJK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provinsi",
                table: "Analisas");

            migrationBuilder.RenameColumn(
                name: "NilaiProvinsi",
                table: "Analisas",
                newName: "Provisi");

            migrationBuilder.CreateTable(
                name: "AnalisaSandiOJKs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppFasilitasKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIGolonganId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIHubunganId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIStatusDebiturId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIKategoriDebiturId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIPortofolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBILembagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIJenisKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBISifatKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIJenisPenggunaanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBITakeOverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIOrientasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIKategoriKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBISukuBungaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBILokasiProyekId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIJenisAgunanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBISifatAgunanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIJenisValutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIPenerbitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIPeringkatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIStatusAgunanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBISkimId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIKreditProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBISumberDanaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AnalisaSandiOJKs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_AppFasilitasKredits_AppFasilitasKreditId",
                        column: x => x.AppFasilitasKreditId,
                        principalTable: "AppFasilitasKredits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIGolonganId",
                        column: x => x.RFSandiBIGolonganId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIHubunganId",
                        column: x => x.RFSandiBIHubunganId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIJenisAgunanId",
                        column: x => x.RFSandiBIJenisAgunanId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIJenisKreditId",
                        column: x => x.RFSandiBIJenisKreditId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIJenisPenggunaanId",
                        column: x => x.RFSandiBIJenisPenggunaanId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIJenisValutaId",
                        column: x => x.RFSandiBIJenisValutaId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIKategoriDebiturId",
                        column: x => x.RFSandiBIKategoriDebiturId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIKategoriKreditId",
                        column: x => x.RFSandiBIKategoriKreditId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIKreditProgramId",
                        column: x => x.RFSandiBIKreditProgramId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBILembagaId",
                        column: x => x.RFSandiBILembagaId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBILokasiProyekId",
                        column: x => x.RFSandiBILokasiProyekId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIOrientasiId",
                        column: x => x.RFSandiBIOrientasiId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIPenerbitId",
                        column: x => x.RFSandiBIPenerbitId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIPeringkatId",
                        column: x => x.RFSandiBIPeringkatId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIPortofolioId",
                        column: x => x.RFSandiBIPortofolioId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBISifatAgunanId",
                        column: x => x.RFSandiBISifatAgunanId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBISifatKreditId",
                        column: x => x.RFSandiBISifatKreditId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBISkimId",
                        column: x => x.RFSandiBISkimId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIStatusAgunanId",
                        column: x => x.RFSandiBIStatusAgunanId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBIStatusDebiturId",
                        column: x => x.RFSandiBIStatusDebiturId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBISukuBungaId",
                        column: x => x.RFSandiBISukuBungaId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBISumberDanaId",
                        column: x => x.RFSandiBISumberDanaId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSandiOJKs_RFSANDIBIS_RFSandiBITakeOverId",
                        column: x => x.RFSandiBITakeOverId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_AnalisaId",
                table: "AnalisaSandiOJKs",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_AppFasilitasKreditId",
                table: "AnalisaSandiOJKs",
                column: "AppFasilitasKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIGolonganId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIGolonganId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIHubunganId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIHubunganId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIJenisAgunanId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIJenisAgunanId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIJenisKreditId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIJenisKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIJenisPenggunaanId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIJenisPenggunaanId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIJenisValutaId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIJenisValutaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIKategoriDebiturId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIKategoriDebiturId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIKategoriKreditId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIKategoriKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIKreditProgramId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIKreditProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBILembagaId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBILembagaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBILokasiProyekId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBILokasiProyekId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIOrientasiId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIOrientasiId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIPenerbitId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIPenerbitId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIPeringkatId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIPeringkatId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIPortofolioId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIPortofolioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBISifatAgunanId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBISifatAgunanId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBISifatKreditId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBISifatKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBISkimId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBISkimId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIStatusAgunanId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIStatusAgunanId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBIStatusDebiturId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBIStatusDebiturId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBISukuBungaId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBISukuBungaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBISumberDanaId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBISumberDanaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSandiOJKs_RFSandiBITakeOverId",
                table: "AnalisaSandiOJKs",
                column: "RFSandiBITakeOverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisaSandiOJKs");

            migrationBuilder.RenameColumn(
                name: "Provisi",
                table: "Analisas",
                newName: "NilaiProvinsi");

            migrationBuilder.AddColumn<string>(
                name: "Provinsi",
                table: "Analisas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
