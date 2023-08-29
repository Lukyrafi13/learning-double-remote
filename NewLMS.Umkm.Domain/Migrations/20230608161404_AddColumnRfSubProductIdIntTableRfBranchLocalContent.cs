using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnRfSubProductIdIntTableRfBranchLocalContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubProductId",
                table: "RfBranchLocalContents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfBranchLocalContents_SubProductId",
                table: "RfBranchLocalContents",
                column: "SubProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfBranchLocalContents_RfSubProducts_SubProductId",
                table: "RfBranchLocalContents",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfBranchLocalContents_RfSubProducts_SubProductId",
                table: "RfBranchLocalContents");

            migrationBuilder.DropIndex(
                name: "IX_RfBranchLocalContents_SubProductId",
                table: "RfBranchLocalContents");

            migrationBuilder.DropColumn(
                name: "SubProductId",
                table: "RfBranchLocalContents");
        }
    }
}
