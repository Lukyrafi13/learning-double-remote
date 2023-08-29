using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectPisahCabang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_RFStages_StageId",
                table: "ProspectStageLogs");

            migrationBuilder.RenameColumn(
                name: "Cabang",
                table: "Prospects",
                newName: "NamaCabang");

            migrationBuilder.AddColumn<string>(
                name: "KodeCabang",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_RFStages_StageId",
                table: "ProspectStageLogs",
                column: "StageId",
                principalTable: "RFStages",
                principalColumn: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_RFStages_StageId",
                table: "ProspectStageLogs");

            migrationBuilder.DropColumn(
                name: "KodeCabang",
                table: "Prospects");

            migrationBuilder.RenameColumn(
                name: "NamaCabang",
                table: "Prospects",
                newName: "Cabang");

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_RFStages_StageId",
                table: "ProspectStageLogs",
                column: "StageId",
                principalTable: "RFStages",
                principalColumn: "StageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
