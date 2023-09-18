using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKRequestStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StageId",
                table: "SLIKRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequests_StageId",
                table: "SLIKRequests",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequests_RfStages_StageId",
                table: "SLIKRequests",
                column: "StageId",
                principalTable: "RfStages",
                principalColumn: "StageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_RfStages_StageId",
                table: "SLIKRequests");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequests_StageId",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "StageId",
                table: "SLIKRequests");
        }
    }
}
