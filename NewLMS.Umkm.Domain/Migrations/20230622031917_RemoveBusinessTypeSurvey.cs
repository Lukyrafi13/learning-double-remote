using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RemoveBusinessTypeSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_RFBusinessTypes_RFBusinessTypeId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_RFBusinessTypeId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "RFBusinessTypeId",
                table: "Surveys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFBusinessTypeId",
                table: "Surveys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_RFBusinessTypeId",
                table: "Surveys",
                column: "RFBusinessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_RFBusinessTypes_RFBusinessTypeId",
                table: "Surveys",
                column: "RFBusinessTypeId",
                principalTable: "RFBusinessTypes",
                principalColumn: "Id");
        }
    }
}
