using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterTableLoanApplicationRemoveDebtorEmergency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DebtorEmergencies_DebtorEmergencyId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DebtorEmergencyId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "DebtorEmergencyId",
                table: "LoanApplications");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorEmergencies_LoanApplications_Id",
                table: "DebtorEmergencies",
                column: "Id",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorEmergencies_LoanApplications_Id",
                table: "DebtorEmergencies");

            migrationBuilder.AddColumn<Guid>(
                name: "DebtorEmergencyId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorEmergencyId",
                table: "LoanApplications",
                column: "DebtorEmergencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DebtorEmergencies_DebtorEmergencyId",
                table: "LoanApplications",
                column: "DebtorEmergencyId",
                principalTable: "DebtorEmergencies",
                principalColumn: "Id");
        }
    }
}
