using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddVerificationNeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationVerificationNeedDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeedsDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationVerificationNeedDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationNeedDetails_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationVerificationNeeds",
                columns: table => new
                {
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PPTKISName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceMentCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LongPlacementTime = table.Column<double>(type: "float", nullable: true),
                    ExtendtedTime = table.Column<double>(type: "float", nullable: true),
                    ApplicationTypeCode = table.Column<int>(type: "int", nullable: true),
                    BirthCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyIncomeForeignCurrency = table.Column<double>(type: "float", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationVerificationNeeds", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationNeeds_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationNeeds_RfParameterDetails_ApplicationTypeCode",
                        column: x => x.ApplicationTypeCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationNeeds_RfPlacementCountries_PlaceMentCountryCode",
                        column: x => x.PlaceMentCountryCode,
                        principalTable: "RfPlacementCountries",
                        principalColumn: "PlacementCountryCode");
                });

            migrationBuilder.CreateTable(
                name: "RfMappingPlafondPlacementCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacementCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationTypeCode = table.Column<int>(type: "int", nullable: true),
                    MaximumPlafond = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_RfMappingPlafondPlacementCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfMappingPlafondPlacementCountries_RfParameterDetails_ApplicationTypeCode",
                        column: x => x.ApplicationTypeCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_RfMappingPlafondPlacementCountries_RfPlacementCountries_PlacementCountryCode",
                        column: x => x.PlacementCountryCode,
                        principalTable: "RfPlacementCountries",
                        principalColumn: "PlacementCountryCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationNeedDetails_LoanApplicationId",
                table: "LoanApplicationVerificationNeedDetails",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationNeeds_ApplicationTypeCode",
                table: "LoanApplicationVerificationNeeds",
                column: "ApplicationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationNeeds_PlaceMentCountryCode",
                table: "LoanApplicationVerificationNeeds",
                column: "PlaceMentCountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingPlafondPlacementCountries_ApplicationTypeCode",
                table: "RfMappingPlafondPlacementCountries",
                column: "ApplicationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingPlafondPlacementCountries_PlacementCountryCode",
                table: "RfMappingPlafondPlacementCountries",
                column: "PlacementCountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationVerificationNeedDetails");

            migrationBuilder.DropTable(
                name: "LoanApplicationVerificationNeeds");

            migrationBuilder.DropTable(
                name: "RfMappingPlafondPlacementCountries");
        }
    }
}
