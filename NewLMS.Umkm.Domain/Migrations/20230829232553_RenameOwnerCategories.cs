using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class RenameOwnerCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFOwnerCategories",
                table: "RFOwnerCategories");

            migrationBuilder.RenameTable(
                name: "RFOwnerCategories",
                newName: "RfOwnerCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfOwnerCategories",
                table: "RfOwnerCategories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfOwnerCategories",
                table: "RfOwnerCategories");

            migrationBuilder.RenameTable(
                name: "RfOwnerCategories",
                newName: "RFOwnerCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFOwnerCategories",
                table: "RFOwnerCategories",
                column: "Id");
        }
    }
}
