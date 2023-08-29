using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddFieldAddressSameAsDebtorToDebtorCoupleAndDebtorEmergency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddressSameAsDebtor",
                table: "DebtorEmergencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddressSameAsDebtor",
                table: "DebtorCouples",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressSameAsDebtor",
                table: "DebtorEmergencies");

            migrationBuilder.DropColumn(
                name: "AddressSameAsDebtor",
                table: "DebtorCouples");
        }
    }
}
