using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSLIKRequestAddColumnBranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "SLIKRequests",
                type: "nvarchar(4)",
                defaultValue: "0000",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequests_BranchId",
                table: "SLIKRequests",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequests_RfBranches_BranchId",
                table: "SLIKRequests",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_RfBranches_BranchId",
                table: "SLIKRequests");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequests_BranchId",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "SLIKRequests");
        }
    }
}
