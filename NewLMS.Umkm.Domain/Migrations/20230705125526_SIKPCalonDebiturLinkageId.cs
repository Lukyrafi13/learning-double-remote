using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SIKPCalonDebiturLinkageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaSIKPId",
                table: "SIKPCalonDebiturs");

            migrationBuilder.RenameColumn(
                name: "RFOwnerCategoryUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                newName: "RFLinkageUsahaSIKPId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                newName: "IX_SIKPCalonDebiturs_RFLinkageUsahaSIKPId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPCalonDebiturs_RFLinkages_RFLinkageUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFLinkageUsahaSIKPId",
                principalTable: "RFLinkages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPCalonDebiturs_RFLinkages_RFLinkageUsahaSIKPId",
                table: "SIKPCalonDebiturs");

            migrationBuilder.RenameColumn(
                name: "RFLinkageUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                newName: "RFOwnerCategoryUsahaSIKPId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPCalonDebiturs_RFLinkageUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                newName: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaSIKPId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaSIKPId",
                table: "SIKPCalonDebiturs",
                column: "RFOwnerCategoryUsahaSIKPId",
                principalTable: "RFOwnerCategories",
                principalColumn: "Id");
        }
    }
}
