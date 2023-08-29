using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class RenameColumnInTableInsurranceRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstallmentRate",
                table: "RfInsuranceRateMappings",
                newName: "InsuranceRate");

            migrationBuilder.RenameColumn(
                name: "InstallmentRateId",
                table: "RfInsuranceRateMappings",
                newName: "InsuranceRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsuranceRate",
                table: "RfInsuranceRateMappings",
                newName: "InstallmentRate");

            migrationBuilder.RenameColumn(
                name: "InsuranceRateId",
                table: "RfInsuranceRateMappings",
                newName: "InstallmentRateId");
        }
    }
}
