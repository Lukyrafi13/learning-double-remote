using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterApprVehicleTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnershipStatus",
                table: "ApprVehicleTemplate",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApprVehicleTemplate_OwnershipStatus",
                table: "ApprVehicleTemplate",
                column: "OwnershipStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprVehicleTemplate_RfParameterDetails_OwnershipStatus",
                table: "ApprVehicleTemplate",
                column: "OwnershipStatus",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprVehicleTemplate_RfParameterDetails_OwnershipStatus",
                table: "ApprVehicleTemplate");

            migrationBuilder.DropIndex(
                name: "IX_ApprVehicleTemplate_OwnershipStatus",
                table: "ApprVehicleTemplate");

            migrationBuilder.AlterColumn<string>(
                name: "OwnershipStatus",
                table: "ApprVehicleTemplate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
