using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class CreateRfBranchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfBranch_BranchId",
                table: "Prospects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfBranch",
                table: "RfBranch");

            migrationBuilder.RenameTable(
                name: "RfBranch",
                newName: "RfBranches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfBranches_BranchId",
                table: "Prospects",
                column: "BranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfBranches_BranchId",
                table: "Prospects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches");

            migrationBuilder.RenameTable(
                name: "RfBranches",
                newName: "RfBranch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfBranch",
                table: "RfBranch",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfBranch_BranchId",
                table: "Prospects",
                column: "BranchId",
                principalTable: "RfBranch",
                principalColumn: "Code");
        }
    }
}
