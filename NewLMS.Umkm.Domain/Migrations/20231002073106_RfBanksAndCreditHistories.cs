using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RfBanksAndCreditHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfBanks",
                columns: table => new
                {
                    BankId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfBanks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditHistories",
                columns: table => new
                {
                    CreditHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKNoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankId = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EconomySector = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Behaviour = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlafondLimit = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    Outstanding = table.Column<int>(type: "int", nullable: false),
                    StuckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Collectibility = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SLIKStatus = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditType = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCreditHistories", x => x.CreditHistoryId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_LoanApplications_LoanApplicationid",
                        column: x => x.LoanApplicationid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "RfBanks",
                        principalColumn: "BankId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfConditions_Condition",
                        column: x => x.Condition,
                        principalTable: "RfConditions",
                        principalColumn: "ConditionCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfCreditTypes_CreditType",
                        column: x => x.CreditType,
                        principalTable: "RfCreditTypes",
                        principalColumn: "CreditTypeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfSandiBIs_ApplicationType",
                        column: x => x.ApplicationType,
                        principalTable: "RfSandiBIs",
                        principalColumn: "RfSandiBIId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfSandiBIs_Behaviour",
                        column: x => x.Behaviour,
                        principalTable: "RfSandiBIs",
                        principalColumn: "RfSandiBIId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfSandiBIs_Collectibility",
                        column: x => x.Collectibility,
                        principalTable: "RfSandiBIs",
                        principalColumn: "RfSandiBIId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfSandiBIs_EconomySector",
                        column: x => x.EconomySector,
                        principalTable: "RfSandiBIs",
                        principalColumn: "RfSandiBIId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_ApplicationType",
                table: "LoanApplicationCreditHistories",
                column: "ApplicationType");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_BankId",
                table: "LoanApplicationCreditHistories",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_Behaviour",
                table: "LoanApplicationCreditHistories",
                column: "Behaviour");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_Collectibility",
                table: "LoanApplicationCreditHistories",
                column: "Collectibility");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_Condition",
                table: "LoanApplicationCreditHistories",
                column: "Condition");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_CreditType",
                table: "LoanApplicationCreditHistories",
                column: "CreditType");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_EconomySector",
                table: "LoanApplicationCreditHistories",
                column: "EconomySector");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditHistories_LoanApplicationid",
                table: "LoanApplicationCreditHistories",
                column: "LoanApplicationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationCreditHistories");

            migrationBuilder.DropTable(
                name: "RfBanks");
        }
    }
}
