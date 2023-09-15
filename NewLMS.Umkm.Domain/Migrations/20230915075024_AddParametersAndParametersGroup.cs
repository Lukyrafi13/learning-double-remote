using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddParametersAndParametersGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationAppraisals_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAppraisals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationAppraisals_RfStages_StageId",
                table: "LoanApplicationAppraisals");

            migrationBuilder.AddColumn<DateTime>(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationAppraisals_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAppraisals",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationAppraisals_RfStages_StageId",
                table: "LoanApplicationAppraisals",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationAppraisals_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAppraisals");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplicationAppraisals_RfStages_StageId",
                table: "LoanApplicationAppraisals");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyEstablishmentDate",
                table: "SIKPRequests");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationAppraisals_LoanApplications_LoanApplicationId",
                table: "LoanApplicationAppraisals",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplicationAppraisals_RfStages_StageId",
                table: "LoanApplicationAppraisals",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId");
        }
    }
}
