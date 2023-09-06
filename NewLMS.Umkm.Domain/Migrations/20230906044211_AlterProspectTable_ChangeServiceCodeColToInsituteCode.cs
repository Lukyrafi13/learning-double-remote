using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterProspectTable_ChangeServiceCodeColToInsituteCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfInstituteCode_ServiceCodeId",
                table: "Prospects");

            migrationBuilder.RenameColumn(
                name: "ServiceCodeId",
                table: "Prospects",
                newName: "InstituteCode");

            migrationBuilder.RenameIndex(
                name: "IX_Prospects_ServiceCodeId",
                table: "Prospects",
                newName: "IX_Prospects_InstituteCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfInstituteCode_InstituteCode",
                table: "Prospects",
                column: "InstituteCode",
                principalTable: "RfInstituteCode",
                principalColumn: "ServiceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfInstituteCode_InstituteCode",
                table: "Prospects");

            migrationBuilder.RenameColumn(
                name: "InstituteCode",
                table: "Prospects",
                newName: "ServiceCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Prospects_InstituteCode",
                table: "Prospects",
                newName: "IX_Prospects_ServiceCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfInstituteCode_ServiceCodeId",
                table: "Prospects",
                column: "ServiceCodeId",
                principalTable: "RfInstituteCode",
                principalColumn: "ServiceCode");
        }
    }
}
