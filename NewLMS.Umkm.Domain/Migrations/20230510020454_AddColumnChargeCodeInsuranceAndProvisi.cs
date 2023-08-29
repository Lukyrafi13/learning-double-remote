using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnChargeCodeInsuranceAndProvisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChargeCodeInsurance",
                table: "RfSubProducts",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargeCodeProvisi",
                table: "RfSubProducts",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargeCodeInsurance",
                table: "RfSubProducts");

            migrationBuilder.DropColumn(
                name: "ChargeCodeProvisi",
                table: "RfSubProducts");
        }
    }
}
