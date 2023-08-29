using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableLoanApplicationAddColumnOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4B352B37-332A-40C6-AB05-E38FCF109719"));

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "LoanApplications");
        }
    }
}
