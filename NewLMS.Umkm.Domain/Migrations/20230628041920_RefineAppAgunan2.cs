using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RefineAppAgunan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatasBarat",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatasSelatan",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatasTimur",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatasUtara",
                table: "AppAgunans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RFJenisAktaId",
                table: "AppAgunans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAgunans_RFJenisAktaId",
                table: "AppAgunans",
                column: "RFJenisAktaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAgunans_RFJenisAktas_RFJenisAktaId",
                table: "AppAgunans",
                column: "RFJenisAktaId",
                principalTable: "RFJenisAktas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAgunans_RFJenisAktas_RFJenisAktaId",
                table: "AppAgunans");

            migrationBuilder.DropIndex(
                name: "IX_AppAgunans_RFJenisAktaId",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "BatasBarat",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "BatasSelatan",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "BatasTimur",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "BatasUtara",
                table: "AppAgunans");

            migrationBuilder.DropColumn(
                name: "RFJenisAktaId",
                table: "AppAgunans");
        }
    }
}
