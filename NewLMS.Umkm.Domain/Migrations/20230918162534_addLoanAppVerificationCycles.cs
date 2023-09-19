using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addLoanAppVerificationCycles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationVerificationCycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessLandFormCode = table.Column<int>(type: "int", nullable: true),
                    BusinessLandAreaCode = table.Column<int>(type: "int", nullable: true),
                    LandArea = table.Column<double>(type: "float", nullable: false),
                    BusinessCapacityCode = table.Column<int>(type: "int", nullable: true),
                    BusinessLandCapacity = table.Column<double>(type: "float", nullable: false),
                    AnnualSales = table.Column<double>(type: "float", nullable: false),
                    NetWorthOfPlaceBusiness = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplicationVerificationCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_RfParameterDetails_BusinessCapacityCode",
                        column: x => x.BusinessCapacityCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_RfParameterDetails_BusinessLandAreaCode",
                        column: x => x.BusinessLandAreaCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationVerificationCycles_RfParameterDetails_BusinessLandFormCode",
                        column: x => x.BusinessLandFormCode,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationCycles_BusinessCapacityCode",
                table: "LoanApplicationVerificationCycles",
                column: "BusinessCapacityCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationCycles_BusinessLandAreaCode",
                table: "LoanApplicationVerificationCycles",
                column: "BusinessLandAreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationVerificationCycles_BusinessLandFormCode",
                table: "LoanApplicationVerificationCycles",
                column: "BusinessLandFormCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationVerificationCycles");
        }
    }
}
