using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDebtorEmergencyZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "DebtorEmergencies");

            migrationBuilder.AddColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorEmergencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_RfZipCodeId",
                table: "DebtorEmergencies",
                column: "RfZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                table: "DebtorEmergencies");

            migrationBuilder.DropIndex(
                name: "IX_DebtorEmergencies_RfZipCodeId",
                table: "DebtorEmergencies");

            migrationBuilder.DropColumn(
                name: "RfZipCodeId",
                table: "DebtorEmergencies");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "DebtorEmergencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
