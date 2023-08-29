using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectRelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs");

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_Prospects_ProspectId",
                table: "ProspectStageLogs",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id");
        }
    }
}
