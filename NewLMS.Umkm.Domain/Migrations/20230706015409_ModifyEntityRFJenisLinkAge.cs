using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyEntityRFJenisLinkAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkCode",
                table: "RFJenisLinkAges");

            migrationBuilder.RenameColumn(
                name: "SIKPCode",
                table: "RFJenisLinkAges",
                newName: "JenisLinkAgeDesc");

            migrationBuilder.RenameColumn(
                name: "LinkDesc",
                table: "RFJenisLinkAges",
                newName: "JenisLinkAgeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JenisLinkAgeDesc",
                table: "RFJenisLinkAges",
                newName: "SIKPCode");

            migrationBuilder.RenameColumn(
                name: "JenisLinkAgeCode",
                table: "RFJenisLinkAges",
                newName: "LinkDesc");

            migrationBuilder.AddColumn<string>(
                name: "LinkCode",
                table: "RFJenisLinkAges",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
