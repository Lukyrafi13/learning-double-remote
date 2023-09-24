using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddSIKPHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SIKPHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoIdentiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanckCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanPlafond = table.Column<double>(type: "float", nullable: true),
                    RateAkad = table.Column<double>(type: "float", nullable: true),
                    LimitActive = table.Column<double>(type: "float", nullable: true),
                    AllowedAkad = table.Column<double>(type: "float", nullable: true),
                    RemainingBookDays = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_SIKPHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SIKPHistoryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SIKPHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BanckCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingDay = table.Column<int>(type: "int", nullable: true),
                    Schema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAkad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxTotalAkad = table.Column<int>(type: "int", nullable: true),
                    AllowedAkad = table.Column<double>(type: "float", nullable: true),
                    RateAkad = table.Column<double>(type: "float", nullable: true),
                    LimitActiveDefault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLimit = table.Column<double>(type: "float", nullable: true),
                    AllowedRemainingPlafond = table.Column<double>(type: "float", nullable: true),
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
                        name: "FK_SIKPHistoryDetails_SIKPHistories_SIKPHistoryId",
                        column: x => x.SIKPHistoryId,
                        principalTable: "SIKPHistories",
                        principalColumn: "Id");
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
                name: "SIKPHistories");
        }
    }
}
