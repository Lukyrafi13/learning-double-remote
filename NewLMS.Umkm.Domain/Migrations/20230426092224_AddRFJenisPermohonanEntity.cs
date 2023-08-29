using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddRFJenisPermohonanEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JenisPermohonanKredit",
                table: "Prospects");

            migrationBuilder.AddColumn<Guid>(
                name: "RFJenisPermohonanId",
                table: "Prospects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RFJenisPermohonans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JenisPermohonan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFJenisPermohonans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFJenisPermohonanId",
                table: "Prospects",
                column: "RFJenisPermohonanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFJenisPermohonans_RFJenisPermohonanId",
                table: "Prospects",
                column: "RFJenisPermohonanId",
                principalTable: "RFJenisPermohonans",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFJenisPermohonans_RFJenisPermohonanId",
                table: "Prospects");

            migrationBuilder.DropTable(
                name: "RFJenisPermohonans");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFJenisPermohonanId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFJenisPermohonanId",
                table: "Prospects");

            migrationBuilder.AddColumn<string>(
                name: "JenisPermohonanKredit",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
