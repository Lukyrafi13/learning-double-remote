using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilitiesAndItsCorrespondingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationInsuranceFees_LoanApplications_LoanApplicationInsuranceFeeId",
                table: "LoanApplicationInsuranceFees");

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationInsuranceFeeId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubmittedFacilities",
                table: "SubmittedFacilities",
                column: "SubmittedFacilityId");

            migrationBuilder.CreateTable(
                name: "SubmittedFacilitiesLogs",
                columns: table => new
                {
                    SubmittedFacilityLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageMark = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedPlafond = table.Column<int>(type: "int", nullable: false),
                    InterestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanTerm = table.Column<int>(type: "int", nullable: false),
                    MaximumPlafond = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    InterestSpread = table.Column<float>(type: "real", nullable: false),
                    InterestTotal = table.Column<float>(type: "real", nullable: false),
                    MonthlyInstallment = table.Column<int>(type: "int", nullable: false),
                    PaymentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPC = table.Column<float>(type: "real", nullable: false),
                    BindingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockParam = table.Column<int>(type: "int", nullable: false),
                    NotaryFee = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SubmittedFacilitiesLogs", x => x.SubmittedFacilityLogId);
                    table.ForeignKey(
                        name: "FK_SubmittedFacilitiesLogs_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedFacilitiesLogs_RfStages_StageMark",
                        column: x => x.StageMark,
                        principalTable: "RfStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationInsuranceFeesLogs",
                columns: table => new
                {
                    LoanApplicationInsuranceFeeLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrokerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CoverageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsurancePremi = table.Column<float>(type: "real", nullable: false),
                    Provision = table.Column<float>(type: "real", nullable: false),
                    ProvisionValue = table.Column<int>(type: "int", nullable: false),
                    CoverageValue = table.Column<int>(type: "int", nullable: false),
                    InsuranceFee = table.Column<int>(type: "int", nullable: false),
                    AdminFee = table.Column<int>(type: "int", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationInsuranceFeesLogs", x => x.LoanApplicationInsuranceFeeLogId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFeesLogs_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFeesLogs_RfInsuranceCompanies_BrokerCode",
                        column: x => x.BrokerCode,
                        principalTable: "RfInsuranceCompanies",
                        principalColumn: "InsuranceCompanyId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFeesLogs_RfInsuranceRateTemplates_CoverageCode",
                        column: x => x.CoverageCode,
                        principalTable: "RfInsuranceRateTemplates",
                        principalColumn: "RfInsuranceRateTemplateCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFeesLogs_SubmittedFacilitiesLogs_LoanApplicationInsuranceFeeLogId",
                        column: x => x.LoanApplicationInsuranceFeeLogId,
                        principalTable: "SubmittedFacilitiesLogs",
                        principalColumn: "SubmittedFacilityLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanApplicationInsuranceFeeId",
                table: "LoanApplications",
                column: "LoanApplicationInsuranceFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceFeesLogs_BrokerCode",
                table: "LoanApplicationInsuranceFeesLogs",
                column: "BrokerCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceFeesLogs_CoverageCode",
                table: "LoanApplicationInsuranceFeesLogs",
                column: "CoverageCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceFeesLogs_LoanApplicationId",
                table: "LoanApplicationInsuranceFeesLogs",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFacilitiesLogs_LoanApplicationId",
                table: "SubmittedFacilitiesLogs",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFacilitiesLogs_StageMark",
                table: "SubmittedFacilitiesLogs",
                column: "StageMark");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationInsuranceFees_SubmittedFacilities_LoanApplicationInsuranceFeeId",
                table: "LoanApplicationInsuranceFees",
                column: "LoanApplicationInsuranceFeeId",
                principalTable: "SubmittedFacilities",
                principalColumn: "SubmittedFacilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_LoanApplicationInsuranceFees_LoanApplicationInsuranceFeeId",
                table: "LoanApplications",
                column: "LoanApplicationInsuranceFeeId",
                principalTable: "LoanApplicationInsuranceFees",
                principalColumn: "LoanApplicationInsuranceFeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationInsuranceFees_SubmittedFacilities_LoanApplicationInsuranceFeeId",
                table: "LoanApplicationInsuranceFees");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_LoanApplicationInsuranceFees_LoanApplicationInsuranceFeeId",
                table: "LoanApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubmittedFacilities",
                table: "SubmittedFacilities");

            migrationBuilder.DropTable(
                name: "LoanApplicationInsuranceFeesLogs");

            migrationBuilder.DropTable(
                name: "SubmittedFacilitiesLogs");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_LoanApplicationInsuranceFeeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LoanApplicationInsuranceFeeId",
                table: "LoanApplications");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationInsuranceFees_LoanApplications_LoanApplicationInsuranceFeeId",
                table: "LoanApplicationInsuranceFees",
                column: "LoanApplicationInsuranceFeeId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
