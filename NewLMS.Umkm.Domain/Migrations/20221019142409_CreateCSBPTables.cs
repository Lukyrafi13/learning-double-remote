using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateCSBPTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfCSBPGroups",
                columns: table => new
                {
                    RfCSBPGroupId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCSBPGroups", x => x.RfCSBPGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RfCSBPs",
                columns: table => new
                {
                    RfCSBPId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RfCSBPGroupId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfCSBPs", x => x.RfCSBPId);
                    table.ForeignKey(
                        name: "FK_RfCSBPs_RfCSBPGroups_RfCSBPGroupId",
                        column: x => x.RfCSBPGroupId,
                        principalTable: "RfCSBPGroups",
                        principalColumn: "RfCSBPGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationComplienceSheets",
                columns: table => new
                {
                    LoanApplicationComplienceSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditIncrease = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BMPK = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DaftarHitamNasional = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CDDDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CDDProfile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SLIK = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DHN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DHNDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankRelations = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KTPLegal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MarriageCertificateLegal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FamilyCertificateLegal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProofOfIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralInsurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditLifeInsurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationComplienceSheets", x => x.LoanApplicationComplienceSheetId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_LoanApplications_LoanApplicationComplienceSheetId",
                        column: x => x.LoanApplicationComplienceSheetId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_BankRelations",
                        column: x => x.BankRelations,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_BMPK",
                        column: x => x.BMPK,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CDDProfile",
                        column: x => x.CDDProfile,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_CreditIncrease",
                        column: x => x.CreditIncrease,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_DaftarHitamNasional",
                        column: x => x.DaftarHitamNasional,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_DHN",
                        column: x => x.DHN,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_KTPLegal",
                        column: x => x.KTPLegal,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_MarriageCertificateLegal",
                        column: x => x.MarriageCertificateLegal,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationComplienceSheets_RfCSBPs_SLIK",
                        column: x => x.SLIK,
                        principalTable: "RfCSBPs",
                        principalColumn: "RfCSBPId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_BankRelations",
                table: "LoanApplicationComplienceSheets",
                column: "BankRelations");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_BMPK",
                table: "LoanApplicationComplienceSheets",
                column: "BMPK");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CDDProfile",
                table: "LoanApplicationComplienceSheets",
                column: "CDDProfile");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_CreditIncrease",
                table: "LoanApplicationComplienceSheets",
                column: "CreditIncrease");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_DaftarHitamNasional",
                table: "LoanApplicationComplienceSheets",
                column: "DaftarHitamNasional");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_DHN",
                table: "LoanApplicationComplienceSheets",
                column: "DHN");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_KTPLegal",
                table: "LoanApplicationComplienceSheets",
                column: "KTPLegal");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_MarriageCertificateLegal",
                table: "LoanApplicationComplienceSheets",
                column: "MarriageCertificateLegal");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationComplienceSheets_SLIK",
                table: "LoanApplicationComplienceSheets",
                column: "SLIK");

            migrationBuilder.CreateIndex(
                name: "IX_RfCSBPs_RfCSBPGroupId",
                table: "RfCSBPs",
                column: "RfCSBPGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationComplienceSheets");

            migrationBuilder.DropTable(
                name: "RfCSBPs");

            migrationBuilder.DropTable(
                name: "RfCSBPGroups");
        }
    }
}
