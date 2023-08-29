using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableForKgbPisan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThridPartyDisbursement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHasDisbursement = table.Column<bool>(type: "bit", nullable: false),
                    AccountOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ThridPartyDisbursement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThridPartyDisbursement_ThridParties_Source",
                        column: x => x.Source,
                        principalTable: "ThridParties",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "ThridPartyDisbursementDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisbursementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<short>(type: "smallint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ThridPartyDisbursementDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThridPartyDisbursementDocument_ThridPartyDisbursement_DisbursementId",
                        column: x => x.DisbursementId,
                        principalTable: "ThridPartyDisbursement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThridPartyDisbursementMonitoring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThridPartyDisbursementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
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
                    table.PrimaryKey("PK_ThridPartyDisbursementMonitoring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThridPartyDisbursementMonitoring_ThridPartyDisbursement_ThridPartyDisbursementId",
                        column: x => x.ThridPartyDisbursementId,
                        principalTable: "ThridPartyDisbursement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThridPartyDisbursement_Source",
                table: "ThridPartyDisbursement",
                column: "Source");

            migrationBuilder.CreateIndex(
                name: "IX_ThridPartyDisbursementDocument_DisbursementId",
                table: "ThridPartyDisbursementDocument",
                column: "DisbursementId");

            migrationBuilder.CreateIndex(
                name: "IX_ThridPartyDisbursementMonitoring_ThridPartyDisbursementId",
                table: "ThridPartyDisbursementMonitoring",
                column: "ThridPartyDisbursementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThridPartyDisbursementDocument");

            migrationBuilder.DropTable(
                name: "ThridPartyDisbursementMonitoring");

            migrationBuilder.DropTable(
                name: "ThridPartyDisbursement");
        }
    }
}
