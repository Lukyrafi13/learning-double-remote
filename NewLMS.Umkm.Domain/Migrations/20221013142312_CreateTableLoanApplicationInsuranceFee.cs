using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class CreateTableLoanApplicationInsuranceFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationInsuranceFees",
                columns: table => new
                {
                    LoanApplicationInsuranceFeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrokerCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CoverageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsurancePremi = table.Column<float>(type: "real", nullable: false),
                    Provision = table.Column<float>(type: "real", nullable: false),
                    ProvisionValue = table.Column<int>(type: "int", nullable: false),
                    CoverageValue = table.Column<int>(type: "int", nullable: false),
                    InsuranceFee = table.Column<int>(type: "int", nullable: false),
                    AdminFee = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplicationInsuranceFees", x => x.LoanApplicationInsuranceFeeId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFees_LoanApplications_LoanApplicationInsuranceFeeId",
                        column: x => x.LoanApplicationInsuranceFeeId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFees_RfInsuranceCompanies_BrokerCode",
                        column: x => x.BrokerCode,
                        principalTable: "RfInsuranceCompanies",
                        principalColumn: "InsuranceCompanyId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceFees_RfInsuranceRateTemplates_CoverageCode",
                        column: x => x.CoverageCode,
                        principalTable: "RfInsuranceRateTemplates",
                        principalColumn: "RfInsuranceRateTemplateCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceFees_BrokerCode",
                table: "LoanApplicationInsuranceFees",
                column: "BrokerCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceFees_CoverageCode",
                table: "LoanApplicationInsuranceFees",
                column: "CoverageCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationInsuranceFees");
        }
    }
}
