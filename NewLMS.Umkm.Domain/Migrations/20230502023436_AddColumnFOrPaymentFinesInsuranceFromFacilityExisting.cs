using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnFOrPaymentFinesInsuranceFromFacilityExisting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "InsuranceCoverage",
                table: "DebtorExistingFacilities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PaymentFinesInsurance",
                table: "DebtorExistingFacilities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PercentagePaymentFinesInsurance",
                table: "DebtorExistingFacilities",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceCoverage",
                table: "DebtorExistingFacilities");

            migrationBuilder.DropColumn(
                name: "PaymentFinesInsurance",
                table: "DebtorExistingFacilities");

            migrationBuilder.DropColumn(
                name: "PercentagePaymentFinesInsurance",
                table: "DebtorExistingFacilities");
        }
    }
}
