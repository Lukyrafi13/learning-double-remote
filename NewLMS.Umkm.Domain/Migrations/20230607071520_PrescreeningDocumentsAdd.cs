using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDocumentsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUrls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FileUrls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFStatusDokumens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFStatusDokumens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFTipeDokumens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFTipeDokumens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrescreeningDokumens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomorDokumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalKadaluarsa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TanggalTBO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Justifikasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFStatusDokumenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PrescreeningDokumens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescreeningDokumens_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescreeningDokumens_RFDocuments_RFDocumentId",
                        column: x => x.RFDocumentId,
                        principalTable: "RFDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrescreeningDokumens_RFStatusDokumens_RFStatusDokumenId",
                        column: x => x.RFStatusDokumenId,
                        principalTable: "RFStatusDokumens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileDokumens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    PrescreeningDokumenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_FileDokumens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDokumens_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FileDokumens_PrescreeningDokumens_PrescreeningDokumenId",
                        column: x => x.PrescreeningDokumenId,
                        principalTable: "PrescreeningDokumens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDokumens_FileUrlId",
                table: "FileDokumens",
                column: "FileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDokumens_PrescreeningDokumenId",
                table: "FileDokumens",
                column: "PrescreeningDokumenId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDokumens_PrescreeningId",
                table: "PrescreeningDokumens",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDokumens_RFDocumentId",
                table: "PrescreeningDokumens",
                column: "RFDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDokumens_RFStatusDokumenId",
                table: "PrescreeningDokumens",
                column: "RFStatusDokumenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDokumens");

            migrationBuilder.DropTable(
                name: "RFTipeDokumens");

            migrationBuilder.DropTable(
                name: "FileUrls");

            migrationBuilder.DropTable(
                name: "PrescreeningDokumens");

            migrationBuilder.DropTable(
                name: "RFStatusDokumens");
        }
    }
}
