using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class ChangeNameColumnFromInsuranceRateTemplateCodeToRfInsuranceRateTemplateCodeInTableRfBranchInsuranceCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.RenameColumn(
                name: "InsuranceTemplateCode",
                table: "RfBranchInsuranceCompanies",
                newName: "RfInsuranceRateTemplateCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceRateTemplates_RfInsuranceRateTemplateCode",
                table: "RfBranchInsuranceCompanies",
                column: "RfInsuranceRateTemplateCode",
                principalTable: "RfInsuranceRateTemplates",
                principalColumn: "RfInsuranceRateTemplateCode");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfBranchInsuranceCompanies_RfInsuranceRateTemplates_RfInsuranceRateTemplateCode",
                table: "RfBranchInsuranceCompanies");


            migrationBuilder.RenameColumn(
                name: "RfInsuranceRateTemplateCode",
                table: "RfBranchInsuranceCompanies",
                newName: "InsuranceTemplateCode");
        }
    }
}
