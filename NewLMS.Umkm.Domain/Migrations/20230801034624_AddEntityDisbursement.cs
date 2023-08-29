using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddEntityDisbursement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disbursements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SppkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersiapanAkadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Disbursements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disbursements_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disbursements_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disbursements_PersiapanAkads_PersiapanAkadId",
                        column: x => x.PersiapanAkadId,
                        principalTable: "PersiapanAkads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disbursements_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disbursements_SPPKs_SppkId",
                        column: x => x.SppkId,
                        principalTable: "SPPKs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RFTempalateAkadKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Urutan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFTempalateAkadKredits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disbursements_AnalisaId",
                table: "Disbursements",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disbursements_AppId",
                table: "Disbursements",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Disbursements_PersiapanAkadId",
                table: "Disbursements",
                column: "PersiapanAkadId");

            migrationBuilder.CreateIndex(
                name: "IX_Disbursements_PrescreeningId",
                table: "Disbursements",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Disbursements_SppkId",
                table: "Disbursements",
                column: "SppkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disbursements");

            migrationBuilder.DropTable(
                name: "RFTempalateAkadKredits");
        }
    }
}
