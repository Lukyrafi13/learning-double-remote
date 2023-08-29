using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddNewEntityDebiturs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debiturs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamaCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaDepanCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaTengahCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaBelakangCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomorTelpon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodePos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KabupatenKota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propinsi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamaAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cabang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisPermohonanKredit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSubSektorEkonomi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alasan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerkiraanPengajuan = table.Column<double>(type: "float", nullable: false),
                    TanggalProspect = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumberData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Debiturs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debiturs_RFGenders_RFGenderId",
                        column: x => x.RFGenderId,
                        principalTable: "RFGenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debiturs_RFOwnerCategories_RFOwnerCategoryId",
                        column: x => x.RFOwnerCategoryId,
                        principalTable: "RFOwnerCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debiturs_RFProducts_RFProductId",
                        column: x => x.RFProductId,
                        principalTable: "RFProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debiturs_RFStatusTargets_RFStatusId",
                        column: x => x.RFStatusId,
                        principalTable: "RFStatusTargets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFGenderId",
                table: "Debiturs",
                column: "RFGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFOwnerCategoryId",
                table: "Debiturs",
                column: "RFOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFProductId",
                table: "Debiturs",
                column: "RFProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Debiturs_RFStatusId",
                table: "Debiturs",
                column: "RFStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debiturs");
        }
    }
}
