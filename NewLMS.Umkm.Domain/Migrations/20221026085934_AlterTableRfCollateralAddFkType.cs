using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfCollateralAddFkType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RfCollateral",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfCollateral_Type",
                table: "RfCollateral",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_RfCollateral_RfColTypePledges_Type",
                table: "RfCollateral",
                column: "Type",
                principalTable: "RfColTypePledges",
                principalColumn: "RfColTypePledgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfCollateral_RfColTypePledges_Type",
                table: "RfCollateral");

            migrationBuilder.DropIndex(
                name: "IX_RfCollateral_Type",
                table: "RfCollateral");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "RfCollateral",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
