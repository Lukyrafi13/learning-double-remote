using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RFStagesId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFStagesId",
                table: "Prospects",
                column: "RFStagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFStages_RFStagesId",
                table: "Prospects",
                column: "RFStagesId",
                principalTable: "RFStages",
                principalColumn: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFStages_RFStagesId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFStagesId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFStagesId",
                table: "Prospects");
        }
    }
}
