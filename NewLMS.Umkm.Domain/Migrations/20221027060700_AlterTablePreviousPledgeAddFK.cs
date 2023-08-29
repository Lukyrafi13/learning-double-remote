using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTablePreviousPledgeAddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PledgeType",
                table: "RfCollateral");

            migrationBuilder.AlterColumn<string>(
                name: "PledgeValue",
                table: "PreviousPledges",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PledgeType",
                table: "PreviousPledges",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "PreviousPledges",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralType",
                table: "PreviousPledges",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralForm",
                table: "PreviousPledges",
                type: "nvarchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_CollateralForm",
                table: "PreviousPledges",
                column: "CollateralForm");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_CollateralType",
                table: "PreviousPledges",
                column: "CollateralType");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_DocumentType",
                table: "PreviousPledges",
                column: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_PledgeType",
                table: "PreviousPledges",
                column: "PledgeType");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_PledgeValue",
                table: "PreviousPledges",
                column: "PledgeValue");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfCollateral_CollateralForm",
                table: "PreviousPledges",
                column: "CollateralForm",
                principalTable: "RfCollateral",
                principalColumn: "CollateralCode");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfColTypePledges_CollateralType",
                table: "PreviousPledges",
                column: "CollateralType",
                principalTable: "RfColTypePledges",
                principalColumn: "RfColTypePledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfDocumentTypes_DocumentType",
                table: "PreviousPledges",
                column: "DocumentType",
                principalTable: "RfDocumentTypes",
                principalColumn: "RfDocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfPledges_PledgeValue",
                table: "PreviousPledges",
                column: "PledgeValue",
                principalTable: "RfPledges",
                principalColumn: "PledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfPledgeTypes_PledgeType",
                table: "PreviousPledges",
                column: "PledgeType",
                principalTable: "RfPledgeTypes",
                principalColumn: "RfPledgeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfCollateral_CollateralForm",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfColTypePledges_CollateralType",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfDocumentTypes_DocumentType",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfPledges_PledgeValue",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfPledgeTypes_PledgeType",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_CollateralForm",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_CollateralType",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_DocumentType",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_PledgeType",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_PledgeValue",
                table: "PreviousPledges");

            migrationBuilder.AddColumn<string>(
                name: "PledgeType",
                table: "RfCollateral",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PledgeValue",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PledgeType",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralType",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CollateralForm",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);
        }
    }
}
