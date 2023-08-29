using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDupRFJenisId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikRequestId",
                table: "PrescreeningDuplikasis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SlikRequestId",
                table: "PrescreeningDuplikasis",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
