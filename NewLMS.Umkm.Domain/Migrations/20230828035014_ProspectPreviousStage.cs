using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectPreviousStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RFPreviousStagesId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFPreviousStagesId",
                table: "Prospects",
                column: "RFPreviousStagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFStages_RFPreviousStagesId",
                table: "Prospects",
                column: "RFPreviousStagesId",
                principalTable: "RFStages",
                principalColumn: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFStages_RFPreviousStagesId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFPreviousStagesId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFPreviousStagesId",
                table: "Prospects");
        }
    }
}
