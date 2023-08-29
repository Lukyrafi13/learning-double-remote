using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableLoanApplicationCreditHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditHistories");

            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditHistories",
                columns: table => new
                {
                    CreditHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKNoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EconomySector = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Behaviour = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ApplicationType = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    PlafondLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outstanding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StuckDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collectibility = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SLIKStatus = table.Column<bool>(type: "bit", nullable: false),
                    LoanApplicationid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_LoanApplicationCreditHistories_RfBanks_BankName",
                        column: x => x.BankName,
                        principalTable: "RfBanks",
                        principalColumn: "BankId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditHistories_RfConditions_Condition",
                        column: x => x.Condition,
                        principalTable: "RfConditions",
                        principalColumn: "ConditionCode");
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
                name: "IX_LoanApplicationCreditHistories_BankName",
                table: "LoanApplicationCreditHistories",
                column: "BankName");

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

            migrationBuilder.CreateTable(
                name: "CreditHistories",
                columns: table => new
                {
                    CreditHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Behaviour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collectibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EconomySector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Outstanding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlafondLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLIKStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StuckDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditHistories", x => x.CreditHistoryId);
                    table.ForeignKey(
                        name: "FK_CreditHistories_LoanApplications_LoanApplicationid",
                        column: x => x.LoanApplicationid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditHistories_LoanApplicationid",
                table: "CreditHistories",
                column: "LoanApplicationid");
        }
    }
}
