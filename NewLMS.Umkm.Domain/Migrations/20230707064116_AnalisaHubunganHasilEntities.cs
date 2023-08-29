using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AnalisaHubunganHasilEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlasanKeterlambatan",
                table: "Analisas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DPD3BulanTerakhir",
                table: "Analisas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ModalSudahDibiayai",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PenghasilanLainnya",
                table: "Analisas",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnalisaFasilitass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FasilitasModalKerja = table.Column<double>(type: "float", nullable: true),
                    SukuBunga = table.Column<double>(type: "float", nullable: true),
                    Angsuran = table.Column<double>(type: "float", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppFasilitasKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFTenorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSubProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AnalisaFasilitass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisaFasilitass_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisaFasilitass_AppFasilitasKredits_AppFasilitasKreditId",
                        column: x => x.AppFasilitasKreditId,
                        principalTable: "AppFasilitasKredits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaFasilitass_RFSubProducts_RFSubProductId",
                        column: x => x.RFSubProductId,
                        principalTable: "RFSubProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalisaFasilitass_RFTenors_RFTenorId",
                        column: x => x.RFTenorId,
                        principalTable: "RFTenors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnalisaPinjamanDariBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinjamanInternal = table.Column<bool>(type: "bit", nullable: true),
                    NamaFasilitas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FasilitasTakeOver = table.Column<bool>(type: "bit", nullable: true),
                    Plafond = table.Column<double>(type: "float", nullable: true),
                    Outstanding = table.Column<double>(type: "float", nullable: true),
                    TanggalMulaiAkad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PinjamanAtasNama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HubunganDengaDebitur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenor = table.Column<double>(type: "float", nullable: true),
                    Bunga = table.Column<double>(type: "float", nullable: true),
                    Angsuran = table.Column<double>(type: "float", nullable: true),
                    BIKolektibilitas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LamaHariMenunggak = table.Column<double>(type: "float", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFLoanPurposeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AnalisaPinjamanDariBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisaPinjamanDariBanks_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisaPinjamanDariBanks_RFLoanPurpose_RFLoanPurposeId",
                        column: x => x.RFLoanPurposeId,
                        principalTable: "RFLoanPurpose",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaFasilitass_AnalisaId",
                table: "AnalisaFasilitass",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaFasilitass_AppFasilitasKreditId",
                table: "AnalisaFasilitass",
                column: "AppFasilitasKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaFasilitass_RFSubProductId",
                table: "AnalisaFasilitass",
                column: "RFSubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaFasilitass_RFTenorId",
                table: "AnalisaFasilitass",
                column: "RFTenorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaPinjamanDariBanks_AnalisaId",
                table: "AnalisaPinjamanDariBanks",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisaPinjamanDariBanks_RFLoanPurposeId",
                table: "AnalisaPinjamanDariBanks",
                column: "RFLoanPurposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisaFasilitass");

            migrationBuilder.DropTable(
                name: "AnalisaPinjamanDariBanks");

            migrationBuilder.DropColumn(
                name: "AlasanKeterlambatan",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "DPD3BulanTerakhir",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "ModalSudahDibiayai",
                table: "Analisas");

            migrationBuilder.DropColumn(
                name: "PenghasilanLainnya",
                table: "Analisas");
        }
    }
}
