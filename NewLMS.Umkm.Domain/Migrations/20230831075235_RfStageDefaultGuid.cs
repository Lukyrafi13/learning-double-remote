using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class RfStageDefaultGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RfStage",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RfStage",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RfStage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StageId",
                table: "RfStage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "SIKPHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NoKTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodeBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SisaHariBook = table.Column<int>(type: "int", nullable: true),
                    Plafond = table.Column<double>(type: "float", nullable: true),
                    InquiryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_SIKPHistories_RfSectorLBU3s_RfSectorLBU3Code",
                        column: x => x.RfSectorLBU3Code,
                        principalTable: "RfSectorLBU3s",
                        principalColumn: "Code");
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
                    TotalLimitDefault = table.Column<double>(type: "float", nullable: true),
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
                        name: "FK_SIKPHistoryDetails_SIKPHistories_SIKPHistoryId",
                        column: x => x.SIKPHistoryId,
                        principalTable: "SIKPHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SIKPHistories_RfSectorLBU3Code",
                table: "SIKPHistories",
                column: "RfSectorLBU3Code");

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

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RfStage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RfStage",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RfStage",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StageId",
                table: "RfStage",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");
        }
    }
}
