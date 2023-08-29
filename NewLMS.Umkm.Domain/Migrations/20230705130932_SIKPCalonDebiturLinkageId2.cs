using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SIKPCalonDebiturLinkageId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaId",
                table: "SIKPCalonDebiturs");

            migrationBuilder.RenameColumn(
                name: "RFOwnerCategoryUsahaId",
                table: "SIKPCalonDebiturs",
                newName: "RFLinkageUsahaId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaId",
                table: "SIKPCalonDebiturs",
                newName: "IX_SIKPCalonDebiturs_RFLinkageUsahaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPCalonDebiturs_RFLinkages_RFLinkageUsahaId",
                table: "SIKPCalonDebiturs",
                column: "RFLinkageUsahaId",
                principalTable: "RFLinkages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPCalonDebiturs_RFLinkages_RFLinkageUsahaId",
                table: "SIKPCalonDebiturs");

            migrationBuilder.RenameColumn(
                name: "RFLinkageUsahaId",
                table: "SIKPCalonDebiturs",
                newName: "RFOwnerCategoryUsahaId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPCalonDebiturs_RFLinkageUsahaId",
                table: "SIKPCalonDebiturs",
                newName: "IX_SIKPCalonDebiturs_RFOwnerCategoryUsahaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPCalonDebiturs_RFOwnerCategories_RFOwnerCategoryUsahaId",
                table: "SIKPCalonDebiturs",
                column: "RFOwnerCategoryUsahaId",
                principalTable: "RFOwnerCategories",
                principalColumn: "Id");
        }
    }
}
