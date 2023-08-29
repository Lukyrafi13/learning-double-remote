using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSubmittedFacilityAddColumnClosedExistingFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClosedExistingFacilityId",
                table: "SubmittedFacilities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedFacilities_ClosedExistingFacilityId",
                table: "SubmittedFacilities",
                column: "ClosedExistingFacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedFacilities_DebtorExistingFacilities_ClosedExistingFacilityId",
                table: "SubmittedFacilities",
                column: "ClosedExistingFacilityId",
                principalTable: "DebtorExistingFacilities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedFacilities_DebtorExistingFacilities_ClosedExistingFacilityId",
                table: "SubmittedFacilities");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedFacilities_ClosedExistingFacilityId",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "ClosedExistingFacilityId",
                table: "SubmittedFacilities");
        }
    }
}
