using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddCreditScoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditScorings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessCycleMonth = table.Column<int>(type: "int", nullable: true),
                    RfBusinessPrimaryCycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BusinessCycle = table.Column<bool>(type: "bit", nullable: true),
                    RFSCOReputasiTempatTinggalId = table.Column<int>(type: "int", nullable: true),
                    RFSCOTingkatKebutuhanId = table.Column<int>(type: "int", nullable: true),
                    RFSCOCaraTransaksiId = table.Column<int>(type: "int", nullable: true),
                    RFSCOPengelolaKeuanganId = table.Column<int>(type: "int", nullable: true),
                    RFSCOHutangPihakLainId = table.Column<int>(type: "int", nullable: true),
                    RFSCOLokTempatUsahaId = table.Column<int>(type: "int", nullable: true),
                    RFSCOHubunganPerbankanId = table.Column<int>(type: "int", nullable: true),
                    RFSCOMutasiPerBulanId = table.Column<int>(type: "int", nullable: true),
                    RFSCORiwayatKreditBJBId = table.Column<int>(type: "int", nullable: true),
                    RFSCOScoringAgunanId = table.Column<int>(type: "int", nullable: true),
                    RFSCOSaldoRekRataId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCreditScorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_LoanApplications_LoanApplicationGuid",
                        column: x => x.LoanApplicationGuid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfBusinessPrimaryCycles_RfBusinessPrimaryCycleId",
                        column: x => x.RfBusinessPrimaryCycleId,
                        principalTable: "RfBusinessPrimaryCycles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOCaraTransaksiId",
                        column: x => x.RFSCOCaraTransaksiId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOHubunganPerbankanId",
                        column: x => x.RFSCOHubunganPerbankanId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOHutangPihakLainId",
                        column: x => x.RFSCOHutangPihakLainId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOLokTempatUsahaId",
                        column: x => x.RFSCOLokTempatUsahaId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOMutasiPerBulanId",
                        column: x => x.RFSCOMutasiPerBulanId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOPengelolaKeuanganId",
                        column: x => x.RFSCOPengelolaKeuanganId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOReputasiTempatTinggalId",
                        column: x => x.RFSCOReputasiTempatTinggalId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCORiwayatKreditBJBId",
                        column: x => x.RFSCORiwayatKreditBJBId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOSaldoRekRataId",
                        column: x => x.RFSCOSaldoRekRataId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOScoringAgunanId",
                        column: x => x.RFSCOScoringAgunanId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_RFSCOTingkatKebutuhanId",
                        column: x => x.RFSCOTingkatKebutuhanId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_LoanApplicationGuid",
                table: "LoanApplicationCreditScorings",
                column: "LoanApplicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RfBusinessPrimaryCycleId",
                table: "LoanApplicationCreditScorings",
                column: "RfBusinessPrimaryCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOCaraTransaksiId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOCaraTransaksiId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOHubunganPerbankanId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOHubunganPerbankanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOHutangPihakLainId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOHutangPihakLainId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOLokTempatUsahaId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOLokTempatUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOMutasiPerBulanId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOMutasiPerBulanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOPengelolaKeuanganId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOPengelolaKeuanganId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOReputasiTempatTinggalId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOReputasiTempatTinggalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCORiwayatKreditBJBId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCORiwayatKreditBJBId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOSaldoRekRataId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOSaldoRekRataId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOScoringAgunanId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOScoringAgunanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_RFSCOTingkatKebutuhanId",
                table: "LoanApplicationCreditScorings",
                column: "RFSCOTingkatKebutuhanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationCreditScorings");
        }
    }
}
