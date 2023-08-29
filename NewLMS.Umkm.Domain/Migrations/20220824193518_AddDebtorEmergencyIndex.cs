using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddDebtorEmergencyIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies",
                column: "DebtorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies",
                column: "DebtorId",
                unique: true,
                filter: "[DebtorId] IS NOT NULL");
        }
    }
}
