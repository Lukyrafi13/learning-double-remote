using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddFasilitasKredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFasilitasKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFLoanPurposeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSubProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlafondYangDiajukan = table.Column<float>(type: "real", nullable: false),
                    RFTenorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TujuanPenggunaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipeCicilan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TingkatSukuBunga = table.Column<float>(type: "real", nullable: false),
                    RFSifatKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AngsuranPokok = table.Column<float>(type: "real", nullable: false),
                    AngsuranBunga = table.Column<float>(type: "real", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisPermohonanKreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFLoanPurpose = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFSubProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFTenor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFSifatKredit = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RFSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_AppFasilitasKredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFJenisPermohonans_RFJenisPermohonanKreditId",
                        column: x => x.RFJenisPermohonanKreditId,
                        principalTable: "RFJenisPermohonans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFLoanPurpose_RFLoanPurposeId",
                        column: x => x.RFLoanPurposeId,
                        principalTable: "RFLoanPurpose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFSectorLBU1s_RFSectorLBU1Code",
                        column: x => x.RFSectorLBU1Code,
                        principalTable: "RFSectorLBU1s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFSectorLBU2s_RFSectorLBU2Code",
                        column: x => x.RFSectorLBU2Code,
                        principalTable: "RFSectorLBU2s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFSectorLBU3s_RFSectorLBU3Code",
                        column: x => x.RFSectorLBU3Code,
                        principalTable: "RFSectorLBU3s",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFSifatKredits_RFSifatKreditId",
                        column: x => x.RFSifatKreditId,
                        principalTable: "RFSifatKredits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFSubProducts_RFSubProductId",
                        column: x => x.RFSubProductId,
                        principalTable: "RFSubProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFasilitasKredits_RFTenors_RFTenorId",
                        column: x => x.RFTenorId,
                        principalTable: "RFTenors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_AppId",
                table: "AppFasilitasKredits",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFJenisPermohonanKreditId",
                table: "AppFasilitasKredits",
                column: "RFJenisPermohonanKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFLoanPurposeId",
                table: "AppFasilitasKredits",
                column: "RFLoanPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFSectorLBU1Code",
                table: "AppFasilitasKredits",
                column: "RFSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFSectorLBU2Code",
                table: "AppFasilitasKredits",
                column: "RFSectorLBU2Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFSectorLBU3Code",
                table: "AppFasilitasKredits",
                column: "RFSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFSifatKreditId",
                table: "AppFasilitasKredits",
                column: "RFSifatKreditId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFSubProductId",
                table: "AppFasilitasKredits",
                column: "RFSubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFasilitasKredits_RFTenorId",
                table: "AppFasilitasKredits",
                column: "RFTenorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFasilitasKredits");
        }
    }
}
