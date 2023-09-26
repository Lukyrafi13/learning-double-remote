using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterDocumentDropFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "DocumentCategory",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentCategory",
                table: "Documents");

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
    }
}
