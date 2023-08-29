using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IntegrateRFJenisKendaraanAgunan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RFJenisKendaraanAgunanId",
                table: "AppAgunans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFJenisKendaraanAgunanId",
                table: "AppAgunans",
                column: "RFJenisKendaraanAgunanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFJenisKendaraanAgunans_RFJenisKendaraanAgunanId",
                table: "AppAgunans",
                column: "RFJenisKendaraanAgunanId",
                principalTable: "RFJenisKendaraanAgunans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFJenisKendaraanAgunans_RFJenisKendaraanAgunanId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFJenisKendaraanAgunanId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFJenisKendaraanAgunanId",
                table: "AppAgunans");
        }
    }
}
