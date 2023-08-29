using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class UpdateTableRfSubProductAdministrationFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProductAdministrations_RfBranches_RfBranchCode",
                table: "SubProductAdministrations");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProductAdministrations_RfSubProducts_RfSubProductId",
                table: "SubProductAdministrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubProductAdministrations",
                table: "SubProductAdministrations");

            migrationBuilder.RenameTable(
                name: "SubProductAdministrations",
                newName: "RfSubProductAdministrations");

            migrationBuilder.RenameIndex(
                name: "IX_SubProductAdministrations_RfSubProductId",
                table: "RfSubProductAdministrations",
                newName: "IX_RfSubProductAdministrations_RfSubProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSubProductAdministrations",
                table: "RfSubProductAdministrations",
                columns: new[] { "RfBranchCode", "RfSubProductId", "LowLimit", "UpperLimit", "Fee", "IsDeleted" });

            migrationBuilder.AddForeignKey(
                name: "FK_RfSubProductAdministrations_RfBranches_RfBranchCode",
                table: "RfSubProductAdministrations",
                column: "RfBranchCode",
                principalTable: "RfBranches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RfSubProductAdministrations_RfSubProducts_RfSubProductId",
                table: "RfSubProductAdministrations",
                column: "RfSubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfSubProductAdministrations_RfBranches_RfBranchCode",
                table: "RfSubProductAdministrations");

            migrationBuilder.DropForeignKey(
                name: "FK_RfSubProductAdministrations_RfSubProducts_RfSubProductId",
                table: "RfSubProductAdministrations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfSubProductAdministrations",
                table: "RfSubProductAdministrations");

            migrationBuilder.RenameTable(
                name: "RfSubProductAdministrations",
                newName: "SubProductAdministrations");

            migrationBuilder.RenameIndex(
                name: "IX_RfSubProductAdministrations_RfSubProductId",
                table: "SubProductAdministrations",
                newName: "IX_SubProductAdministrations_RfSubProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubProductAdministrations",
                table: "SubProductAdministrations",
                columns: new[] { "RfBranchCode", "RfSubProductId", "IsDeleted" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubProductAdministrations_RfBranches_RfBranchCode",
                table: "SubProductAdministrations",
                column: "RfBranchCode",
                principalTable: "RfBranches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProductAdministrations_RfSubProducts_RfSubProductId",
                table: "SubProductAdministrations",
                column: "RfSubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
