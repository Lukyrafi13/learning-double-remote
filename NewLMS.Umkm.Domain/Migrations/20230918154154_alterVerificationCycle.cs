using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterVerificationCycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationVerificationCycles");

            migrationBuilder.CreateTable(
                name: "LoanApplicationVerificationBusinesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservationTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurnoverValueTurnOver = table.Column<double>(type: "float", nullable: false),
                    AnnualSalesTurnOver = table.Column<double>(type: "float", nullable: false),
                    NetWorthTurnOver = table.Column<double>(type: "float", nullable: false),
                    BasicConsiderationTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterviewGPM = table.Column<double>(type: "float", nullable: false),
                    ObservationGPM = table.Column<double>(type: "float", nullable: false),
                    MaximumStandardGPM = table.Column<double>(type: "float", nullable: false),
                    LowestGrossProfitMarginGPM = table.Column<double>(type: "float", nullable: false),
                    PurchaseCostValueGPM = table.Column<double>(type: "float", nullable: false),
                    PurchaseCostPercentGPM = table.Column<double>(type: "float", nullable: false),
                    LaborCosts = table.Column<double>(type: "float", nullable: false),
                    VenueElectricityCosts = table.Column<double>(type: "float", nullable: false),
                    PremisesWaterFees = table.Column<double>(type: "float", nullable: false),
                    TelephoneCallFee = table.Column<double>(type: "float", nullable: false),
                    CellphoneFee = table.Column<double>(type: "float", nullable: false),
                    OperatingCosts = table.Column<double>(type: "float", nullable: false),
                    TotalBusinessCost = table.Column<double>(type: "float", nullable: false),
                    InterviewHouseHold = table.Column<double>(type: "float", nullable: false),
                    HouseholdExpenses = table.Column<double>(type: "float", nullable: false),
                    VerificationResultsHouseHold = table.Column<double>(type: "float", nullable: false),
                    HighestCostResultsHouseHold = table.Column<double>(type: "float", nullable: false),
                    AmountStockpile = table.Column<double>(type: "float", nullable: false),
                    AmountReceivable = table.Column<double>(type: "float", nullable: false),
                    TotalDebt = table.Column<double>(type: "float", nullable: false),
                    FundedBusiness = table.Column<bool>(type: "bit", nullable: false),
                    BusinessLocation = table.Column<bool>(type: "bit", nullable: false),
                    DebtorsBusiness = table.Column<bool>(type: "bit", nullable: false),
                    BusinessOwnershipCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OldBusinessLocationCode = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationVerificationBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationBusinesses_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationBusinesses_RfBusinessPlaceOwnerships_BusinessOwnershipCode",
                        column: x => x.BusinessOwnershipCode,
                        principalTable: "RfBusinessPlaceOwnerships",
                        principalColumn: "BusinessPlaceOwnCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationBusinesses_RfParameterDetails_OldBusinessLocationCode",
                        column: x => x.OldBusinessLocationCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationBusinesses_BusinessOwnershipCode",
                table: "LoanApplicationVerificationBusinesses",
                column: "BusinessOwnershipCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationBusinesses_OldBusinessLocationCode",
                table: "LoanApplicationVerificationBusinesses",
                column: "OldBusinessLocationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationVerificationBusinesses");

            migrationBuilder.CreateTable(
                name: "LoanApplicationVerificationCycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessOwnershipCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OldBusinessLocationCode = table.Column<int>(type: "int", nullable: true),
                    AmountReceivable = table.Column<double>(type: "float", nullable: false),
                    AmountStockpile = table.Column<double>(type: "float", nullable: false),
                    AnnualSalesTurnOver = table.Column<double>(type: "float", nullable: false),
                    BasicConsiderationTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation = table.Column<bool>(type: "bit", nullable: false),
                    CellphoneFee = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DebtorsBusiness = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FundedBusiness = table.Column<bool>(type: "bit", nullable: false),
                    HighestCostResultsHouseHold = table.Column<double>(type: "float", nullable: false),
                    HouseholdExpenses = table.Column<double>(type: "float", nullable: false),
                    InterviewGPM = table.Column<double>(type: "float", nullable: false),
                    InterviewHouseHold = table.Column<double>(type: "float", nullable: false),
                    InterviewTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LaborCosts = table.Column<double>(type: "float", nullable: false),
                    LowestGrossProfitMarginGPM = table.Column<double>(type: "float", nullable: false),
                    MaximumStandardGPM = table.Column<double>(type: "float", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetWorthTurnOver = table.Column<double>(type: "float", nullable: false),
                    NotesTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObservationGPM = table.Column<double>(type: "float", nullable: false),
                    ObservationTurnOver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingCosts = table.Column<double>(type: "float", nullable: false),
                    PremisesWaterFees = table.Column<double>(type: "float", nullable: false),
                    PurchaseCostPercentGPM = table.Column<double>(type: "float", nullable: false),
                    PurchaseCostValueGPM = table.Column<double>(type: "float", nullable: false),
                    TelephoneCallFee = table.Column<double>(type: "float", nullable: false),
                    TotalBusinessCost = table.Column<double>(type: "float", nullable: false),
                    TotalDebt = table.Column<double>(type: "float", nullable: false),
                    TurnoverValueTurnOver = table.Column<double>(type: "float", nullable: false),
                    VenueElectricityCosts = table.Column<double>(type: "float", nullable: false),
                    VerificationResultsHouseHold = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationVerificationCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_RfBusinessPlaceOwnerships_BusinessOwnershipCode",
                        column: x => x.BusinessOwnershipCode,
                        principalTable: "RfBusinessPlaceOwnerships",
                        principalColumn: "BusinessPlaceOwnCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_RfParameterDetails_OldBusinessLocationCode",
                        column: x => x.OldBusinessLocationCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationCycles_BusinessOwnershipCode",
                table: "LoanApplicationVerificationCycles",
                column: "BusinessOwnershipCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationCycles_OldBusinessLocationCode",
                table: "LoanApplicationVerificationCycles",
                column: "OldBusinessLocationCode");
        }
    }
}
