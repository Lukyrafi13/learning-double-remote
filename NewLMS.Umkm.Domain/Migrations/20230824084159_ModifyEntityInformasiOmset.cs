using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyEntityInformasiOmset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformasiOmsets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BentukLahanUsaha = table.Column<int>(type: "int", nullable: true),
                    LuasLahanUsaha = table.Column<int>(type: "int", nullable: true),
                    KapasitasLahanUsaha = table.Column<int>(type: "int", nullable: true),
                    PenjualanTahunan = table.Column<int>(type: "int", nullable: true),
                    KekayaanBersih = table.Column<int>(type: "int", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BentukLahanUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LuasLahanUsahaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_InformasiOmsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformasiOmsets_RFBentukLahans_BentukLahanUsahaId",
                        column: x => x.BentukLahanUsahaId,
                        principalTable: "RFBentukLahans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformasiOmsets_RFSatuanLuass_LuasLahanUsahaId",
                        column: x => x.LuasLahanUsahaId,
                        principalTable: "RFSatuanLuass",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformasiOmsets_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformasiOmsets_BentukLahanUsahaId",
                table: "InformasiOmsets",
                column: "BentukLahanUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_InformasiOmsets_LuasLahanUsahaId",
                table: "InformasiOmsets",
                column: "LuasLahanUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_InformasiOmsets_SurveyId",
                table: "InformasiOmsets",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformasiOmsets");
        }
    }
}
