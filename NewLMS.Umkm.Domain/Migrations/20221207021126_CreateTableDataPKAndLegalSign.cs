using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableDataPKAndLegalSign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataPKs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedSigningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreditContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstInsuranceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDateCredit = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_DataPKs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPKs_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalSigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BindingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pemutus1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalDomicile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoSK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SigningPK = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SigningNota = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SigningPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpousePresence = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_LegalSigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalSigns_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalSigns_SCUsers_SigningNota",
                        column: x => x.SigningNota,
                        principalTable: "SCUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_LegalSigns_SCUsers_SigningPK",
                        column: x => x.SigningPK,
                        principalTable: "SCUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPKs_LoanApplicationId",
                table: "DataPKs",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalSigns_LoanApplicationId",
                table: "LegalSigns",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalSigns_SigningNota",
                table: "LegalSigns",
                column: "SigningNota");

            migrationBuilder.CreateIndex(
                name: "IX_LegalSigns_SigningPK",
                table: "LegalSigns",
                column: "SigningPK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPKs");

            migrationBuilder.DropTable(
                name: "LegalSigns");
        }
    }
}
