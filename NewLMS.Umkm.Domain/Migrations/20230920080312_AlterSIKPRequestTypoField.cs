using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPRequestTypoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfLinkAges_DebtorCompanyLingkageId",
                table: "SIKPRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfLinkAges_DebtorCompanyLingkageId",
                table: "SIKPResponses");

            migrationBuilder.RenameColumn(
                name: "DebtorCompanyLingkageId",
                table: "SIKPResponses",
                newName: "DebtorCompanyLinkageId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPResponses_DebtorCompanyLingkageId",
                table: "SIKPResponses",
                newName: "IX_SIKPResponses_DebtorCompanyLinkageId");

            migrationBuilder.RenameColumn(
                name: "DebtorCompanyLingkageId",
                table: "SIKPRequests",
                newName: "DebtorCompanyLinkageId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPRequests_DebtorCompanyLingkageId",
                table: "SIKPRequests",
                newName: "IX_SIKPRequests_DebtorCompanyLinkageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfLinkAges_DebtorCompanyLinkageId",
                table: "SIKPRequests",
                column: "DebtorCompanyLinkageId",
                principalTable: "RfLinkAges",
                principalColumn: "LinkAgeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfLinkAges_DebtorCompanyLinkageId",
                table: "SIKPResponses",
                column: "DebtorCompanyLinkageId",
                principalTable: "RfLinkAges",
                principalColumn: "LinkAgeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfLinkAges_DebtorCompanyLinkageId",
                table: "SIKPRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfLinkAges_DebtorCompanyLinkageId",
                table: "SIKPResponses");

            migrationBuilder.RenameColumn(
                name: "DebtorCompanyLinkageId",
                table: "SIKPResponses",
                newName: "DebtorCompanyLingkageId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPResponses_DebtorCompanyLinkageId",
                table: "SIKPResponses",
                newName: "IX_SIKPResponses_DebtorCompanyLingkageId");

            migrationBuilder.RenameColumn(
                name: "DebtorCompanyLinkageId",
                table: "SIKPRequests",
                newName: "DebtorCompanyLingkageId");

            migrationBuilder.RenameIndex(
                name: "IX_SIKPRequests_DebtorCompanyLinkageId",
                table: "SIKPRequests",
                newName: "IX_SIKPRequests_DebtorCompanyLingkageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfLinkAges_DebtorCompanyLingkageId",
                table: "SIKPRequests",
                column: "DebtorCompanyLingkageId",
                principalTable: "RfLinkAges",
                principalColumn: "LinkAgeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfLinkAges_DebtorCompanyLingkageId",
                table: "SIKPResponses",
                column: "DebtorCompanyLingkageId",
                principalTable: "RfLinkAges",
                principalColumn: "LinkAgeCode");
        }
    }
}
