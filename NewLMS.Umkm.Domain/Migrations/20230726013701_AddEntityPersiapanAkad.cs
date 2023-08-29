using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddEntityPersiapanAkad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersiapanAkads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SppkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersiapanAkads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersiapanAkads_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersiapanAkads_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersiapanAkads_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersiapanAkads_SPPKs_SppkId",
                        column: x => x.SppkId,
                        principalTable: "SPPKs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewPersiapanAkads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SppkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersiapanAkadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewPersiapanAkads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewPersiapanAkads_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewPersiapanAkads_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewPersiapanAkads_PersiapanAkads_PersiapanAkadId",
                        column: x => x.PersiapanAkadId,
                        principalTable: "PersiapanAkads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewPersiapanAkads_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewPersiapanAkads_SPPKs_SppkId",
                        column: x => x.SppkId,
                        principalTable: "SPPKs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VerifikasiPersiapanAkads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SppkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnalisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersiapanAkadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifikasiPersiapanAkads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerifikasiPersiapanAkads_Analisas_AnalisaId",
                        column: x => x.AnalisaId,
                        principalTable: "Analisas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerifikasiPersiapanAkads_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerifikasiPersiapanAkads_PersiapanAkads_PersiapanAkadId",
                        column: x => x.PersiapanAkadId,
                        principalTable: "PersiapanAkads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerifikasiPersiapanAkads_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerifikasiPersiapanAkads_SPPKs_SppkId",
                        column: x => x.SppkId,
                        principalTable: "SPPKs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkads_AnalisaId",
                table: "PersiapanAkads",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkads_AppId",
                table: "PersiapanAkads",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkads_PrescreeningId",
                table: "PersiapanAkads",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_PersiapanAkads_SppkId",
                table: "PersiapanAkads",
                column: "SppkId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPersiapanAkads_AnalisaId",
                table: "ReviewPersiapanAkads",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPersiapanAkads_AppId",
                table: "ReviewPersiapanAkads",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPersiapanAkads_PersiapanAkadId",
                table: "ReviewPersiapanAkads",
                column: "PersiapanAkadId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPersiapanAkads_PrescreeningId",
                table: "ReviewPersiapanAkads",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPersiapanAkads_SppkId",
                table: "ReviewPersiapanAkads",
                column: "SppkId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikasiPersiapanAkads_AnalisaId",
                table: "VerifikasiPersiapanAkads",
                column: "AnalisaId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikasiPersiapanAkads_AppId",
                table: "VerifikasiPersiapanAkads",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikasiPersiapanAkads_PersiapanAkadId",
                table: "VerifikasiPersiapanAkads",
                column: "PersiapanAkadId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikasiPersiapanAkads_PrescreeningId",
                table: "VerifikasiPersiapanAkads",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikasiPersiapanAkads_SppkId",
                table: "VerifikasiPersiapanAkads",
                column: "SppkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewPersiapanAkads");

            migrationBuilder.DropTable(
                name: "VerifikasiPersiapanAkads");

            migrationBuilder.DropTable(
                name: "PersiapanAkads");
        }
    }
}
