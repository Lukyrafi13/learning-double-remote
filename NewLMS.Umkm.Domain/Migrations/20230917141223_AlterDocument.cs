using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppraisalGuid",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AppraisalGuid",
                table: "Documents",
                column: "AppraisalGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_LoanApplicationAppraisals_AppraisalGuid",
                table: "Documents",
                column: "AppraisalGuid",
                principalTable: "LoanApplicationAppraisals",
                principalColumn: "AppraisalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_LoanApplicationAppraisals_AppraisalGuid",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AppraisalGuid",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AppraisalGuid",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Documents");
        }
    }
}
