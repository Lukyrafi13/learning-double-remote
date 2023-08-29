using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTablePreviousUpdateFKPledgeValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfPledges_PledgeValue",
                table: "PreviousPledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfPledgeTypes_PledgeType",
                table: "PreviousPledges");

            migrationBuilder.DropIndex(
                name: "IX_PreviousPledges_PledgeValue",
                table: "PreviousPledges");

            migrationBuilder.AlterColumn<string>(
                name: "PledgeValue",
                table: "PreviousPledges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PreviousPledges_RfPledges_PledgeType",
                table: "PreviousPledges",
                column: "PledgeType",
                principalTable: "RfPledges",
                principalColumn: "PledgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreviousPledges_RfPledges_PledgeType",
                table: "PreviousPledges");

            migrationBuilder.AlterColumn<string>(
                name: "PledgeValue",
                table: "PreviousPledges",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousPledges_PledgeValue",
                table: "PreviousPledges",
                column: "PledgeValue");

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
    }
}
