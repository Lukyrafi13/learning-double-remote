using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addRfDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentId",
                table: "Documents",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_RfDocuments_DocumentId",
                table: "Documents",
                column: "DocumentId",
                principalTable: "RfDocuments",
                principalColumn: "DocumentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_RfDocuments_DocumentId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Documents");
        }
    }
}
