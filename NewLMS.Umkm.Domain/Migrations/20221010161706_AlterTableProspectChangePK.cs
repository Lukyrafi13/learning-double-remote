using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableProspectChangePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Prospects_ProspectId",
                table: "LoanApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prospects",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ProspectId",
                table: "LoanApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProspectGuid",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prospects",
                table: "Prospects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectGuid",
                table: "LoanApplications",
                column: "ProspectGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Prospects_ProspectGuid",
                table: "LoanApplications",
                column: "ProspectGuid",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Prospects_ProspectGuid",
                table: "LoanApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prospects",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ProspectGuid",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "ProspectGuid",
                table: "LoanApplications");

            migrationBuilder.AddColumn<string>(
                name: "ProspectId",
                table: "LoanApplications",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prospects",
                table: "Prospects",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications",
                column: "ProspectId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Prospects_ProspectId",
                table: "LoanApplications",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "ProspectId",
                onDelete: ReferentialAction.Cascade);

        }
    }
}
