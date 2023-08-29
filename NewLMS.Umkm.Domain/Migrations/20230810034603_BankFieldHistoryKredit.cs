using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class BankFieldHistoryKredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikHistoryKredits_RFBanks_RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropIndex(
                name: "IX_SlikHistoryKredits_RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "RFBankId",
                table: "SlikHistoryKredits");

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "SlikHistoryKredits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "SlikHistoryKredits");

            migrationBuilder.AddColumn<Guid>(
                name: "RFBankId",
                table: "SlikHistoryKredits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_RFBankId",
                table: "SlikHistoryKredits",
                column: "RFBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikHistoryKredits_RFBanks_RFBankId",
                table: "SlikHistoryKredits",
                column: "RFBankId",
                principalTable: "RFBanks",
                principalColumn: "Id");
        }
    }
}
