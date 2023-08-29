using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class NegaraPenempatanGuidNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                column: "RFNegaraPenempatanId",
                principalTable: "RFNegaraPenempatans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits");

            migrationBuilder.AlterColumn<Guid>(
                name: "RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppFasilitasKredits_RFNegaraPenempatans_RFNegaraPenempatanId",
                table: "AppFasilitasKredits",
                column: "RFNegaraPenempatanId",
                principalTable: "RFNegaraPenempatans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
