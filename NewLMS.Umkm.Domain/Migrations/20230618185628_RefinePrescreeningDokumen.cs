using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RefinePrescreeningDokumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DokumenLainnya",
                table: "PrescreeningDokumens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUploadDate",
                table: "PrescreeningDokumens",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DokumenLainnya",
                table: "PrescreeningDokumens");

            migrationBuilder.DropColumn(
                name: "LastUploadDate",
                table: "PrescreeningDokumens");
        }
    }
}
