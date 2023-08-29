using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDebtorCoupleAddColumnsAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DebtorCouples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhoods",
                table: "DebtorCouples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RT",
                table: "DebtorCouples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RW",
                table: "DebtorCouples",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfZipCodeId",
                table: "DebtorCouples",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCouples_RfZipCodeId",
                table: "DebtorCouples",
                column: "RfZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onUpdate: ReferentialAction.Cascade,
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                table: "DebtorCouples");

            migrationBuilder.DropIndex(
                name: "IX_DebtorCouples_RfZipCodeId",
                table: "DebtorCouples");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DebtorCouples");

            migrationBuilder.DropColumn(
                name: "Neighborhoods",
                table: "DebtorCouples");

            migrationBuilder.DropColumn(
                name: "RT",
                table: "DebtorCouples");

            migrationBuilder.DropColumn(
                name: "RW",
                table: "DebtorCouples");

            migrationBuilder.DropColumn(
                name: "RfZipCodeId",
                table: "DebtorCouples");
        }
    }
}
