using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterProspectWithParameterDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfAppTypes_RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfCompanyGroups_RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfCompanyStatuses_RfCompanyStatusId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfCompanyStatusId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfCompanyStatusId",
                table: "Prospects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RfAppTypeId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RfCompanyGroupId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RfCompanyStatusId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfAppTypeId",
                table: "Prospects",
                column: "RfAppTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyGroupId",
                table: "Prospects",
                column: "RfCompanyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyStatusId",
                table: "Prospects",
                column: "RfCompanyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfAppTypes_RfAppTypeId",
                table: "Prospects",
                column: "RfAppTypeId",
                principalTable: "RfAppTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfCompanyGroups_RfCompanyGroupId",
                table: "Prospects",
                column: "RfCompanyGroupId",
                principalTable: "RfCompanyGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfCompanyStatuses_RfCompanyStatusId",
                table: "Prospects",
                column: "RfCompanyStatusId",
                principalTable: "RfCompanyStatuses",
                principalColumn: "Id");
        }
    }
}
