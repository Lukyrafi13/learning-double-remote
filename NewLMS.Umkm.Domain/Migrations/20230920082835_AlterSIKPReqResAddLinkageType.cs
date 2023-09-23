using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterSIKPReqResAddLinkageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DebtorCompanyLinkageTypeId",
                table: "SIKPResponses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebtorCompanyLinkageTypeId",
                table: "SIKPRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPResponses_DebtorCompanyLinkageTypeId",
                table: "SIKPResponses",
                column: "DebtorCompanyLinkageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SIKPRequests_DebtorCompanyLinkageTypeId",
                table: "SIKPRequests",
                column: "DebtorCompanyLinkageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPRequests_RfLinkAgeTypes_DebtorCompanyLinkageTypeId",
                table: "SIKPRequests",
                column: "DebtorCompanyLinkageTypeId",
                principalTable: "RfLinkAgeTypes",
                principalColumn: "LinkAgeTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPResponses_RfLinkAgeTypes_DebtorCompanyLinkageTypeId",
                table: "SIKPResponses",
                column: "DebtorCompanyLinkageTypeId",
                principalTable: "RfLinkAgeTypes",
                principalColumn: "LinkAgeTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPRequests_RfLinkAgeTypes_DebtorCompanyLinkageTypeId",
                table: "SIKPRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SIKPResponses_RfLinkAgeTypes_DebtorCompanyLinkageTypeId",
                table: "SIKPResponses");

            migrationBuilder.DropIndex(
                name: "IX_SIKPResponses_DebtorCompanyLinkageTypeId",
                table: "SIKPResponses");

            migrationBuilder.DropIndex(
                name: "IX_SIKPRequests_DebtorCompanyLinkageTypeId",
                table: "SIKPRequests");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyLinkageTypeId",
                table: "SIKPResponses");

            migrationBuilder.DropColumn(
                name: "DebtorCompanyLinkageTypeId",
                table: "SIKPRequests");
        }
    }
}
