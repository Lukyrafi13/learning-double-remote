using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableForInsuranceAndFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfInsuranceCompanies",
                columns: table => new
                {
                    InsuranceCompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InsuranceCompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneArea = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneExt = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FaxArea = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RekFire = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RekLife = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FormulaId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CoreId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                    table.PrimaryKey("PK_RfInsuranceCompanies", x => x.InsuranceCompanyId);
                    table.ForeignKey(
                        name: "FK_RfInsuranceCompanies_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfInsuranceRateTemplates",
                columns: table => new
                {
                    RfInsuranceRateTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RfInsuranceRateTemplateDescription = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfInsuranceRateTemplates", x => x.RfInsuranceRateTemplateCode);
                });

            migrationBuilder.CreateTable(
                name: "RfInsuranceTemplates",
                columns: table => new
                {
                    InsuranceTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InsuranceTemplateType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    InsuranceTemplateDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfInsuranceTemplates", x => x.InsuranceTemplateCode);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationInsuranceLives",
                columns: table => new
                {
                    LoanApplicationInsuranceLifeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: true),
                    InsuranceCompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InsuranceTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    InsurancePlanCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LifeInsurancePolicyFee = table.Column<double>(type: "float", nullable: true),
                    LifeInsurancePremi = table.Column<double>(type: "float", nullable: true),
                    LifeCommisionPercent = table.Column<double>(type: "float", nullable: true),
                    LifeInsuranceValue = table.Column<double>(type: "float", nullable: true),
                    LifeInsurancePlafond = table.Column<double>(type: "float", nullable: true),
                    IsBroker = table.Column<bool>(type: "bit", nullable: true),
                    LifeInsuraneYear = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationInsuranceLives", x => x.LoanApplicationInsuranceLifeId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceLives_LoanApplications_LoanApplicationNo",
                        column: x => x.LoanApplicationNo,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceLives_RfInsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "RfInsuranceCompanies",
                        principalColumn: "InsuranceCompanyId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationInsuranceLives_RfInsuranceTemplates_InsuranceTemplateCode",
                        column: x => x.InsuranceTemplateCode,
                        principalTable: "RfInsuranceTemplates",
                        principalColumn: "InsuranceTemplateCode");
                });

            migrationBuilder.CreateTable(
                name: "RfBranchInsuranceCompanies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    InsuranceCompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InsuranceTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfBranchInsuranceCompanies", x => new { x.Code, x.InsuranceCompanyId });
                    table.ForeignKey(
                        name: "FK_RfBranchInsuranceCompanies_RfBranches_Code",
                        column: x => x.Code,
                        principalTable: "RfBranches",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfBranchInsuranceCompanies_RfInsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "RfInsuranceCompanies",
                        principalColumn: "InsuranceCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RfBranchInsuranceCompanies_RfInsuranceTemplates_InsuranceTemplateCode",
                        column: x => x.InsuranceTemplateCode,
                        principalTable: "RfInsuranceTemplates",
                        principalColumn: "InsuranceTemplateCode");
                });

            migrationBuilder.CreateTable(
                name: "RfInsuranceCompanyTemplates",
                columns: table => new
                {
                    InsuranceCompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InsuranceTemplateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.ForeignKey(
                        name: "FK_RfInsuranceCompanyTemplates_RfInsuranceCompanies_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "RfInsuranceCompanies",
                        principalColumn: "InsuranceCompanyId");
                    table.ForeignKey(
                        name: "FK_RfInsuranceCompanyTemplates_RfInsuranceTemplates_InsuranceTemplateCode",
                        column: x => x.InsuranceTemplateCode,
                        principalTable: "RfInsuranceTemplates",
                        principalColumn: "InsuranceTemplateCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceLives_InsuranceCompanyId",
                table: "LoanApplicationInsuranceLives",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceLives_InsuranceTemplateCode",
                table: "LoanApplicationInsuranceLives",
                column: "InsuranceTemplateCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationInsuranceLives_LoanApplicationNo",
                table: "LoanApplicationInsuranceLives",
                column: "LoanApplicationNo");

            migrationBuilder.CreateIndex(
                name: "IX_RfBranchInsuranceCompanies_InsuranceCompanyId",
                table: "RfBranchInsuranceCompanies",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RfBranchInsuranceCompanies_InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies",
                column: "InsuranceTemplateCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfInsuranceCompanies_RfZipCodeId",
                table: "RfInsuranceCompanies",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfInsuranceCompanyTemplates_InsuranceCompanyId",
                table: "RfInsuranceCompanyTemplates",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RfInsuranceCompanyTemplates_InsuranceTemplateCode",
                table: "RfInsuranceCompanyTemplates",
                column: "InsuranceTemplateCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "LoanApplicationInsuranceLives");

            migrationBuilder.DropTable(
                name: "RfBranchInsuranceCompanies");

            migrationBuilder.DropTable(
                name: "RfInsuranceCompanyTemplates");

            migrationBuilder.DropTable(
                name: "RfInsuranceRateTemplates");

            migrationBuilder.DropTable(
                name: "RfInsuranceCompanies");

            migrationBuilder.DropTable(
                name: "RfInsuranceTemplates");
        }
    }
}
