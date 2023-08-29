using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddEntitySPPKFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SPPKFileUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SPPKId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Judul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TanggalUpload = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadOleh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_SPPKFileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SPPKFileUploads_FileUrls_FileUrlId",
                        column: x => x.FileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SPPKFileUploads_SPPKs_SPPKId",
                        column: x => x.SPPKId,
                        principalTable: "SPPKs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SPPKFileUploads_FileUrlId",
                table: "SPPKFileUploads",
                column: "FileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_SPPKFileUploads_SPPKId",
                table: "SPPKFileUploads",
                column: "SPPKId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPPKFileUploads");
        }
    }
}
