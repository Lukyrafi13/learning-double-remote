using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SIKPHistoryAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SIKPHistorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SisaHariBook = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_SIKPHistorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SIKPHistoryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KodeBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SisaHari = table.Column<int>(type: "int", nullable: true),
                    Skema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JumlahAkad = table.Column<int>(type: "int", nullable: true),
                    MaxJumlahAkad = table.Column<int>(type: "int", nullable: true),
                    RateAkad = table.Column<double>(type: "float", nullable: true),
                    LimitAktifDefault = table.Column<double>(type: "float", nullable: true),
                    LimitAktif = table.Column<double>(type: "float", nullable: true),
                    TotalLimit = table.Column<double>(type: "float", nullable: true),
                    SIKPHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_SIKPHistoryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIKPHistoryDetails_SIKPHistorys_SIKPHistoryId",
                        column: x => x.SIKPHistoryId,
                        principalTable: "SIKPHistorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIKPHistoryDetails_SIKPHistoryId",
                table: "SIKPHistoryDetails",
                column: "SIKPHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SIKPHistoryDetails");

            migrationBuilder.DropTable(
                name: "SIKPHistorys");
        }
    }
}
