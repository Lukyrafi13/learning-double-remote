using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationSubmittedFacilityAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities");

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "SubmittedFacilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "SubmittedFacilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "DuplicationChecked",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFacilities_LoanApplicationId",
                table: "SubmittedFacilities",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFacilities_StageId",
                table: "SubmittedFacilities",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_LoanApplicationId",
                table: "SubmittedFacilities",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_RfStages_StageId",
                table: "SubmittedFacilities",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_LoanApplicationId",
                table: "SubmittedFacilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_RfStages_StageId",
                table: "SubmittedFacilities");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedFacilities_LoanApplicationId",
                table: "SubmittedFacilities");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedFacilities_StageId",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "DuplicationChecked",
                table: "LoanApplications");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                table: "SubmittedFacilities",
                column: "SubmittedFacilityId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
