using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterLoanApplicationChangeDecisionMakerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_DecisionMakerId",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<string>(
                name: "DecisionMakerId",
                table: "LoanApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfDecisionMakers_DecisionMakerId",
                table: "LoanApplications",
                column: "DecisionMakerId",
                principalTable: "RfDecisionMakers",
                principalColumn: "DecisionMakerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfDecisionMakers_DecisionMakerId",
                table: "LoanApplications");

            migrationBuilder.AlterColumn<Guid>(
                name: "DecisionMakerId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_DecisionMakerId",
                table: "LoanApplications",
                column: "DecisionMakerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
