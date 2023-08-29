using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyRFSCOTingkatKebutuhan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOTINGKATKEBUTUHAN",
                newName: "CORE_CODE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOTINGKATKEBUTUHAN",
                newName: "CORE_DESC");
        }
    }
}
