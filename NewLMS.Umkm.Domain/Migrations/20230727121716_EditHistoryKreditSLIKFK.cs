using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditHistoryKreditSLIKFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "CreditType",
                table: "SlikHistoryKredits");

            migrationBuilder.AddColumn<Guid>(
                name: "RFBankId",
                table: "SlikHistoryKredits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFConditionId",
                table: "SlikHistoryKredits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFTipeKreditId",
                table: "SlikHistoryKredits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFBankId",
                table: "SlikHistoryKredits",
                column: "RFBankId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFConditionId",
                table: "SlikHistoryKredits",
                column: "RFConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFTipeKreditId",
                table: "SlikHistoryKredits",
                column: "RFTipeKreditId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikHistoryKredits_RFBanks_RFBankId",
                table: "SlikHistoryKredits",
                column: "RFBankId",
                principalTable: "RFBanks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikHistoryKredits_RFConditions_RFConditionId",
                table: "SlikHistoryKredits",
                column: "RFConditionId",
                principalTable: "RFConditions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikHistoryKredits_RFTipeKredits_RFTipeKreditId",
                table: "SlikHistoryKredits",
                column: "RFTipeKreditId",
                principalTable: "RFTipeKredits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikHistoryKredits_RFBanks_RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikHistoryKredits_RFConditions_RFConditionId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikHistoryKredits_RFTipeKredits_RFTipeKreditId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropIndex(
                name: "IX_SlikHistoryKredits_RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropIndex(
                name: "IX_SlikHistoryKredits_RFConditionId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropIndex(
                name: "IX_SlikHistoryKredits_RFTipeKreditId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "RFConditionId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "RFTipeKreditId",
                table: "SlikHistoryKredits");

            migrationBuilder.AddColumn<string>(
                name: "BankId",
                table: "SlikHistoryKredits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "SlikHistoryKredits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditType",
                table: "SlikHistoryKredits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
