using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKHistoryKredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlikHistoryKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKNoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RFSandiBIEconomySectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIBehaviourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIApplicationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlafondLimit = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    Outstanding = table.Column<int>(type: "int", nullable: false),
                    StuckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RFSandiBICollectibilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SLIKStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRobo = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SlikHistoryKredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikHistoryKredits_RFSANDIBIS_RFSandiBIApplicationTypeId",
                        column: x => x.RFSandiBIApplicationTypeId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikHistoryKredits_RFSANDIBIS_RFSandiBIBehaviourId",
                        column: x => x.RFSandiBIBehaviourId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikHistoryKredits_RFSANDIBIS_RFSandiBICollectibilityId",
                        column: x => x.RFSandiBICollectibilityId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikHistoryKredits_RFSANDIBIS_RFSandiBIEconomySectorId",
                        column: x => x.RFSandiBIEconomySectorId,
                        principalTable: "RFSANDIBIS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikHistoryKredits_SlikRequests_SlikRequestId",
                        column: x => x.SlikRequestId,
                        principalTable: "SlikRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFSandiBIApplicationTypeId",
                table: "SlikHistoryKredits",
                column: "RFSandiBIApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFSandiBIBehaviourId",
                table: "SlikHistoryKredits",
                column: "RFSandiBIBehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFSandiBICollectibilityId",
                table: "SlikHistoryKredits",
                column: "RFSandiBICollectibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFSandiBIEconomySectorId",
                table: "SlikHistoryKredits",
                column: "RFSandiBIEconomySectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_SlikRequestId",
                table: "SlikHistoryKredits",
                column: "SlikRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlikHistoryKredits");
        }
    }
}
