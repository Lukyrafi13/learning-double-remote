using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addFieldSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationFieldSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SurveyorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationsWithDebtorsId = table.Column<int>(type: "int", nullable: true),
                    OwnerCategoryId = table.Column<int>(type: "int", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocationStatusId = table.Column<int>(type: "int", nullable: true),
                    YearStandingBusiness = table.Column<int>(type: "int", nullable: true),
                    MonthStandingBusiness = table.Column<int>(type: "int", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: true),
                    NumberOfBranches = table.Column<int>(type: "int", nullable: true),
                    BusinessFieldKURId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressSameAsDebtor = table.Column<bool>(type: "bit", nullable: false),
                    SurveyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    ConclusionVerification = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationFieldSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_RfBusinessFieldKURs_BusinessFieldKURId",
                        column: x => x.BusinessFieldKURId,
                        principalTable: "RfBusinessFieldKURs",
                        principalColumn: "BusinessFieldKURCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_RfParameterDetails_BusinessLocationStatusId",
                        column: x => x.BusinessLocationStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_RfParameterDetails_OwnerCategoryId",
                        column: x => x.OwnerCategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_RfParameterDetails_RelationsWithDebtorsId",
                        column: x => x.RelationsWithDebtorsId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFieldSurveys_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFieldSurveys_BusinessFieldKURId",
                table: "LoanApplicationFieldSurveys",
                column: "BusinessFieldKURId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFieldSurveys_BusinessLocationStatusId",
                table: "LoanApplicationFieldSurveys",
                column: "BusinessLocationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFieldSurveys_OwnerCategoryId",
                table: "LoanApplicationFieldSurveys",
                column: "OwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFieldSurveys_RelationsWithDebtorsId",
                table: "LoanApplicationFieldSurveys",
                column: "RelationsWithDebtorsId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFieldSurveys_ZipCodeId",
                table: "LoanApplicationFieldSurveys",
                column: "ZipCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationFieldSurveys");
        }
    }
}
