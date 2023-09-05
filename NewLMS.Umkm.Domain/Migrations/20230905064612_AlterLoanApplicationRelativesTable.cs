using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplicationRelativesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCompanies_DebtorEmergencies_DebtorEmergencyId",
                table: "DebtorCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_RfParameterDetails_RfHomestaParameterDetailId",
                table: "Debtors");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_BookingOfficeCode",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_RfBranchCode",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplicationCollateralOwners_RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropIndex(
                name: "IX_Debtors_RfHomestaParameterDetailId",
                table: "Debtors");

            migrationBuilder.DropIndex(
                name: "IX_DebtorCompanies_DebtorEmergencyId",
                table: "DebtorCompanies");

            migrationBuilder.DropColumn(
                name: "RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners");

            migrationBuilder.DropColumn(
                name: "RfHomestaParameterDetailId",
                table: "Debtors");

            migrationBuilder.DropColumn(
                name: "DebtorEmergencyId",
                table: "DebtorCompanies");

            migrationBuilder.RenameColumn(
                name: "RfBranchCode",
                table: "LoanApplications",
                newName: "BranchId");

            migrationBuilder.RenameColumn(
                name: "BookingOfficeCode",
                table: "LoanApplications",
                newName: "BookingBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_RfBranchCode",
                table: "LoanApplications",
                newName: "IX_LoanApplications_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_BookingOfficeCode",
                table: "LoanApplications",
                newName: "IX_LoanApplications_BookingBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_BookingBranchId",
                table: "LoanApplications",
                column: "BookingBranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_BranchId",
                table: "LoanApplications",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_BookingBranchId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_BranchId",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "LoanApplications",
                newName: "RfBranchCode");

            migrationBuilder.RenameColumn(
                name: "BookingBranchId",
                table: "LoanApplications",
                newName: "BookingOfficeCode");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_BranchId",
                table: "LoanApplications",
                newName: "IX_LoanApplications_RfBranchCode");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_BookingBranchId",
                table: "LoanApplications",
                newName: "IX_LoanApplications_BookingOfficeCode");

            migrationBuilder.AddColumn<int>(
                name: "RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfHomestaParameterDetailId",
                table: "Debtors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DebtorEmergencyId",
                table: "DebtorCompanies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners",
                column: "RfHomestaParameterDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfHomestaParameterDetailId",
                table: "Debtors",
                column: "RfHomestaParameterDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_DebtorEmergencyId",
                table: "DebtorCompanies",
                column: "DebtorEmergencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCompanies_DebtorEmergencies_DebtorEmergencyId",
                table: "DebtorCompanies",
                column: "DebtorEmergencyId",
                principalTable: "DebtorEmergencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_RfParameterDetails_RfHomestaParameterDetailId",
                table: "Debtors",
                column: "RfHomestaParameterDetailId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners",
                column: "RfHomestaParameterDetailId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_BookingOfficeCode",
                table: "LoanApplications",
                column: "BookingOfficeCode",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_RfBranchCode",
                table: "LoanApplications",
                column: "RfBranchCode",
                principalTable: "RfBranches",
                principalColumn: "Code");
        }
    }
}
