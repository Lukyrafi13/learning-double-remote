using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditZipCodesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfZipCodes",
                table: "RfZipCodes");

            migrationBuilder.RenameTable(
                name: "RfZipCodes",
                newName: "RFZipCodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFZipCodes",
                table: "RFZipCodes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFZipCodes",
                table: "RFZipCodes");

            migrationBuilder.RenameTable(
                name: "RFZipCodes",
                newName: "RfZipCodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfZipCodes",
                table: "RfZipCodes",
                column: "Id");
        }
    }
}
