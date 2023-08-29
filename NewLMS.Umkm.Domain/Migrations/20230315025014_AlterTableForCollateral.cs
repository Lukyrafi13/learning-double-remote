using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AlterTableForCollateral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHasCollateral",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "LoanApplicationId",
                table: "DebtorCollaterals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCollaterals_LoanApplicationId",
                table: "DebtorCollaterals",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCollaterals_LoanApplications_LoanApplicationId",
                table: "DebtorCollaterals",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCollaterals_LoanApplications_LoanApplicationId",
                table: "DebtorCollaterals");

            migrationBuilder.DropIndex(
                name: "IX_DebtorCollaterals_LoanApplicationId",
                table: "DebtorCollaterals");

            migrationBuilder.DropColumn(
                name: "IsHasCollateral",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "DebtorCollaterals");
        }
    }
}
