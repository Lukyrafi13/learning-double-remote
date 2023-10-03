using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterGeneratedFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationCollateralGuid",
                table: "GeneratedFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedFiles_LoanApplicationCollateralGuid",
                table: "GeneratedFiles",
                column: "LoanApplicationCollateralGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedFiles_LoanApplicationCollaterals_LoanApplicationCollateralGuid",
                table: "GeneratedFiles",
                column: "LoanApplicationCollateralGuid",
                principalTable: "LoanApplicationCollaterals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedFiles_LoanApplicationCollaterals_LoanApplicationCollateralGuid",
                table: "GeneratedFiles");

            migrationBuilder.DropIndex(
                name: "IX_GeneratedFiles_LoanApplicationCollateralGuid",
                table: "GeneratedFiles");

            migrationBuilder.DropColumn(
                name: "LoanApplicationCollateralGuid",
                table: "GeneratedFiles");
        }
    }
}
