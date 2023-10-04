using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddLoanAppBusinessInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationBusinessInformation",
                columns: table => new
                {
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessAddressSameWithApplication = table.Column<bool>(type: "bit", nullable: false),
                    BusinessLocationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistanceBusinessLocation = table.Column<double>(type: "float", nullable: true),
                    BusinessPlaceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermitsHeld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusinessPlaceLocationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusinessPlaceOwnCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OtherBusinessPalceOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<double>(type: "float", nullable: true),
                    MarketingAspectCode = table.Column<int>(type: "int", nullable: true),
                    NumberOfPermanentEmployeeCode = table.Column<int>(type: "int", nullable: true),
                    NumberOfDailyEmployeeCode = table.Column<int>(type: "int", nullable: true),
                    LongTimeInBusiness = table.Column<double>(type: "float", nullable: true),
                    LongStayBusinessPlace = table.Column<double>(type: "float", nullable: true),
                    DebtorHaveOtherBusiness = table.Column<bool>(type: "bit", nullable: false),
                    DebtorOtherBusiness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherBusinessDurationCode = table.Column<int>(type: "int", nullable: true),
                    DebtorBusinessNotAvoided = table.Column<bool>(type: "bit", nullable: false),
                    BusinessActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationBusinessInformation", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfBusinessLocations_BusinessLocationCode",
                        column: x => x.BusinessLocationCode,
                        principalTable: "RfBusinessLocations",
                        principalColumn: "BusinessLocationCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfBusinessPlaceLocations_BusinessPlaceLocationCode",
                        column: x => x.BusinessPlaceLocationCode,
                        principalTable: "RfBusinessPlaceLocations",
                        principalColumn: "RfBusinessPlaceLocationCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfBusinessPlaceOwnerships_BusinessPlaceOwnCode",
                        column: x => x.BusinessPlaceOwnCode,
                        principalTable: "RfBusinessPlaceOwnerships",
                        principalColumn: "BusinessPlaceOwnCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfBusinessPlaceTypes_BusinessPlaceTypeCode",
                        column: x => x.BusinessPlaceTypeCode,
                        principalTable: "RfBusinessPlaceTypes",
                        principalColumn: "BusinessPlaceTypeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfBusinessTypes_BusinessTypeCode",
                        column: x => x.BusinessTypeCode,
                        principalTable: "RfBusinessTypes",
                        principalColumn: "BusinessTypeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfParameterDetails_MarketingAspectCode",
                        column: x => x.MarketingAspectCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfParameterDetails_NumberOfDailyEmployeeCode",
                        column: x => x.NumberOfDailyEmployeeCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfParameterDetails_NumberOfPermanentEmployeeCode",
                        column: x => x.NumberOfPermanentEmployeeCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationBusinessInformation_RfParameterDetails_OtherBusinessDurationCode",
                        column: x => x.OtherBusinessDurationCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_BusinessLocationCode",
                table: "LoanApplicationBusinessInformation",
                column: "BusinessLocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_BusinessPlaceLocationCode",
                table: "LoanApplicationBusinessInformation",
                column: "BusinessPlaceLocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_BusinessPlaceOwnCode",
                table: "LoanApplicationBusinessInformation",
                column: "BusinessPlaceOwnCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_BusinessPlaceTypeCode",
                table: "LoanApplicationBusinessInformation",
                column: "BusinessPlaceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_BusinessTypeCode",
                table: "LoanApplicationBusinessInformation",
                column: "BusinessTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_MarketingAspectCode",
                table: "LoanApplicationBusinessInformation",
                column: "MarketingAspectCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_NumberOfDailyEmployeeCode",
                table: "LoanApplicationBusinessInformation",
                column: "NumberOfDailyEmployeeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_NumberOfPermanentEmployeeCode",
                table: "LoanApplicationBusinessInformation",
                column: "NumberOfPermanentEmployeeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationBusinessInformation_OtherBusinessDurationCode",
                table: "LoanApplicationBusinessInformation",
                column: "OtherBusinessDurationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationBusinessInformation");
        }
    }
}
