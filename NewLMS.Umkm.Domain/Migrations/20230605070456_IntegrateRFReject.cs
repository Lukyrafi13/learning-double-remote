using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IntegrateRFReject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFRejectId",
                table: "ProspectStageLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProspectStageLogs_RFRejectId",
                table: "ProspectStageLogs",
                column: "RFRejectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProspectStageLogs_RFRejects_RFRejectId",
                table: "ProspectStageLogs",
                column: "RFRejectId",
                principalTable: "RFRejects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProspectStageLogs_RFRejects_RFRejectId",
                table: "ProspectStageLogs");

            migrationBuilder.DropIndex(
                name: "IX_ProspectStageLogs_RFRejectId",
                table: "ProspectStageLogs");

            migrationBuilder.DropColumn(
                name: "RFRejectId",
                table: "ProspectStageLogs");
        }
    }
}
