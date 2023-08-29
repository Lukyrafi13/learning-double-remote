using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AppAgunan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAgunans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomorDokumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TglTerbitDokumen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TglExpireDokumen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TahunProduksi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KotaDomisiliBerdasarkanSTNK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgunanMilikDebitur = table.Column<bool>(type: "bit", nullable: true),
                    NamaPemilik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorIDPemilik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BerlakuSampaiDengan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeumurHidup = table.Column<bool>(type: "bit", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTelpKontakDarurat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFMappingAgunan2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFVehMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFVehClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFRelationColId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFZipCodeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AppAgunans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAgunans_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFDocuments_RFDocumentId",
                        column: x => x.RFDocumentId,
                        principalTable: "RFDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFMappingAgunan2s_RFMappingAgunan2Id",
                        column: x => x.RFMappingAgunan2Id,
                        principalTable: "RFMappingAgunan2s",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFRelationCols_RFRelationColId",
                        column: x => x.RFRelationColId,
                        principalTable: "RFRelationCols",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFVEHCLASS_RFVehClassId",
                        column: x => x.RFVehClassId,
                        principalTable: "RFVEHCLASS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFVEHMAKER_RFVehMakerId",
                        column: x => x.RFVehMakerId,
                        principalTable: "RFVEHMAKER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppAgunans_RFZipCodes_RFZipCodeId",
                        column: x => x.RFZipCodeId,
                        principalTable: "RFZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_AppId",
                table: "AppAgunans",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFDocumentId",
                table: "AppAgunans",
                column: "RFDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFMappingAgunan2Id",
                table: "AppAgunans",
                column: "RFMappingAgunan2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFRelationColId",
                table: "AppAgunans",
                column: "RFRelationColId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFVehClassId",
                table: "AppAgunans",
                column: "RFVehClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFVehMakerId",
                table: "AppAgunans",
                column: "RFVehMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFZipCodeId",
                table: "AppAgunans",
                column: "RFZipCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAgunans");
        }
    }
}
