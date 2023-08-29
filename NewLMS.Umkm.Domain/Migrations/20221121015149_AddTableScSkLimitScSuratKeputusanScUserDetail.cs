using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableScSkLimitScSuratKeputusanScUserDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SKCode",
                table: "SCJabatans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ScSuratKeputusan",
                columns: table => new
                {
                    SkCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkHal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SkClausal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Limit = table.Column<float>(type: "real", nullable: true),
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
                    table.PrimaryKey("PK_ScSuratKeputusan", x => x.SkCode);
                });

            migrationBuilder.CreateTable(
                name: "ScUserDetail",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JabCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SKMutasiCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitUser = table.Column<float>(type: "real", nullable: true),
                    SkCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkMutasiTgl = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SkMutasiHal = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ScUserDetail", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ScUserDetail_SCJabatans_JabCode",
                        column: x => x.JabCode,
                        principalTable: "SCJabatans",
                        principalColumn: "JabCode");
                    table.ForeignKey(
                        name: "FK_ScUserDetail_SCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCSKLIMITs",
                columns: table => new
                {
                    SkCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Limit = table.Column<float>(type: "real", nullable: true),
                    Deviation = table.Column<bool>(type: "bit", nullable: true),
                    LimitRpc = table.Column<float>(type: "real", nullable: true),
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
                    table.PrimaryKey("PK_SCSKLIMITs", x => new { x.SkCode, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SCSKLIMITs_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCSKLIMITs_ScSuratKeputusan_SkCode",
                        column: x => x.SkCode,
                        principalTable: "ScSuratKeputusan",
                        principalColumn: "SkCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCJabatans_SKCode",
                table: "SCJabatans",
                column: "SKCode");

            migrationBuilder.CreateIndex(
                name: "IX_SCSKLIMITs_ProductId",
                table: "SCSKLIMITs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ScUserDetail_JabCode",
                table: "ScUserDetail",
                column: "JabCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusan_SKCode",
                table: "SCJabatans",
                column: "SKCode",
                principalTable: "ScSuratKeputusan",
                principalColumn: "SkCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCJabatans_ScSuratKeputusan_SKCode",
                table: "SCJabatans");

            migrationBuilder.DropTable(
                name: "SCSKLIMITs");

            migrationBuilder.DropTable(
                name: "ScUserDetail");

            migrationBuilder.DropTable(
                name: "ScSuratKeputusan");

            migrationBuilder.DropIndex(
                name: "IX_SCJabatans_SKCode",
                table: "SCJabatans");

            migrationBuilder.AlterColumn<string>(
                name: "SKCode",
                table: "SCJabatans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
