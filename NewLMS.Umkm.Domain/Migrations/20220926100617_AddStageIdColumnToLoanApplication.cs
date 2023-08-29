using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddStageIdColumnToLoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("D605AAA1-DB9F-75E0-23F5-9686012CE684"));

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_StageId",
                table: "LoanApplications",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfStages_StageId",
                table: "LoanApplications",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfStages_StageId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_StageId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "LoanApplications");
        }
    }
}
