using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFJenisSyaratKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SyaratCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyaratDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RFJenisSyaratKredits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFLokasiUsahas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANL_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ANL_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFLokasiUsahas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlamatUsahaSamaDenganAplikasi = table.Column<bool>(type: "bit", nullable: true),
                    JarakLokasiUsahaDariCabang = table.Column<double>(type: "float", nullable: true),
                    PerijinanYangDimiliki = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nomor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RACMemilikiUsaha = table.Column<bool>(type: "bit", nullable: true),
                    LamaUsaha = table.Column<int>(type: "int", nullable: true),
                    LamaMenempatiTempatUsaha = table.Column<int>(type: "int", nullable: true),
                    MemilikiUsahaLain = table.Column<bool>(type: "bit", nullable: true),
                    UsahaTidakTermasukJenisDihindari = table.Column<bool>(type: "bit", nullable: true),
                    AktifitasUsaha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFLokasiUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJenisTempatUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFKelompokUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJenisUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFLokasiTempatUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFBuktiKepemilikanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFAspekPemasaranId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJumlahPegawaiTetapId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFJumlahPegawaiHarianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Analisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analisas_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFAspekPemasarans_RFAspekPemasaranId",
                        column: x => x.RFAspekPemasaranId,
                        principalTable: "RFAspekPemasarans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFBuktiKepemilikans_RFBuktiKepemilikanId",
                        column: x => x.RFBuktiKepemilikanId,
                        principalTable: "RFBuktiKepemilikans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFJenisTempatUsahas_RFJenisTempatUsahaId",
                        column: x => x.RFJenisTempatUsahaId,
                        principalTable: "RFJenisTempatUsahas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFJenisUsahas_RFJenisUsahaId",
                        column: x => x.RFJenisUsahaId,
                        principalTable: "RFJenisUsahas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFJumlahPegawais_RFJumlahPegawaiHarianId",
                        column: x => x.RFJumlahPegawaiHarianId,
                        principalTable: "RFJumlahPegawais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFJumlahPegawais_RFJumlahPegawaiTetapId",
                        column: x => x.RFJumlahPegawaiTetapId,
                        principalTable: "RFJumlahPegawais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFKelompokUsahas_RFKelompokUsahaId",
                        column: x => x.RFKelompokUsahaId,
                        principalTable: "RFKelompokUsahas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFLokasiTempatUsahas_RFLokasiTempatUsahaId",
                        column: x => x.RFLokasiTempatUsahaId,
                        principalTable: "RFLokasiTempatUsahas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_RFLokasiUsahas_RFLokasiUsahaId",
                        column: x => x.RFLokasiUsahaId,
                        principalTable: "RFLokasiUsahas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analisas_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnalisaSyaratKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deskripsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Catatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisSyaratKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFDecisionSKId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AnalisaSyaratKredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisaSyaratKredits_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisaSyaratKredits_RFDecisionSKs_RFDecisionSKId",
                        column: x => x.RFDecisionSKId,
                        principalTable: "RFDecisionSKs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaSyaratKredits_RFJenisSyaratKredits_RFJenisSyaratKreditId",
                        column: x => x.RFJenisSyaratKreditId,
                        principalTable: "RFJenisSyaratKredits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_AppId",
                table: "Analisas",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_PrescreeningId",
                table: "Analisas",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFAspekPemasaranId",
                table: "Analisas",
                column: "RFAspekPemasaranId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFBuktiKepemilikanId",
                table: "Analisas",
                column: "RFBuktiKepemilikanId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFJenisTempatUsahaId",
                table: "Analisas",
                column: "RFJenisTempatUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFJenisUsahaId",
                table: "Analisas",
                column: "RFJenisUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFJumlahPegawaiHarianId",
                table: "Analisas",
                column: "RFJumlahPegawaiHarianId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFJumlahPegawaiTetapId",
                table: "Analisas",
                column: "RFJumlahPegawaiTetapId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFKelompokUsahaId",
                table: "Analisas",
                column: "RFKelompokUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFLokasiTempatUsahaId",
                table: "Analisas",
                column: "RFLokasiTempatUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_RFLokasiUsahaId",
                table: "Analisas",
                column: "RFLokasiUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisas_SurveyId",
                table: "Analisas",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSyaratKredits_AnalisaId",
                table: "AnalisaSyaratKredits",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSyaratKredits_RFDecisionSKId",
                table: "AnalisaSyaratKredits",
                column: "RFDecisionSKId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaSyaratKredits_RFJenisSyaratKreditId",
                table: "AnalisaSyaratKredits",
                column: "RFJenisSyaratKreditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisaSyaratKredits");

            migrationBuilder.DropTable(
                name: "Analisas");

            migrationBuilder.DropTable(
                name: "RFJenisSyaratKredits");

            migrationBuilder.DropTable(
                name: "RFLokasiUsahas");
        }
    }
}
