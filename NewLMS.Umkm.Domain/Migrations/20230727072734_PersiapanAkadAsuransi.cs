using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PersiapanAkadAsuransi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersiapanAkadAsuransis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NilaiPertanggungan = table.Column<double>(type: "float", nullable: true),
                    Premi = table.Column<double>(type: "float", nullable: true),
                    NomorPolis = table.Column<double>(type: "float", nullable: true),
                    JangkaWaktuPertanggungan = table.Column<int>(type: "int", nullable: true),
                    ObjekPertanggunganJiwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjekPertanggunganLainnya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersiapanAkadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisAsuransiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFColLateralBCId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PersiapanAkadAsuransis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersiapanAkadAsuransis_PersiapanAkads_PersiapanAkadId",
                        column: x => x.PersiapanAkadId,
                        principalTable: "PersiapanAkads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersiapanAkadAsuransis_RFColLateralBCs_RFColLateralBCId",
                        column: x => x.RFColLateralBCId,
                        principalTable: "RFColLateralBCs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkadAsuransis_PersiapanAkadId",
                table: "PersiapanAkadAsuransis",
                column: "PersiapanAkadId");

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkadAsuransis_RFColLateralBCId",
                table: "PersiapanAkadAsuransis",
                column: "RFColLateralBCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersiapanAkadAsuransis");
        }
    }
}
