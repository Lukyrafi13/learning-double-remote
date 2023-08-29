using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfBranchInsuranceCompanyChangeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceTemplates_InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceRateTemplates_InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies",
                column: "InsuranceTemplateCode",
                principalTable: "RfInsuranceRateTemplates",
                principalColumn: "RfInsuranceRateTemplateCode");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceRateTemplates_InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies");

            migrationBuilder.AddForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceTemplates_InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies",
                column: "InsuranceTemplateCode",
                principalTable: "RfInsuranceTemplates",
                principalColumn: "InsuranceTemplateCode");
        }
    }
}
