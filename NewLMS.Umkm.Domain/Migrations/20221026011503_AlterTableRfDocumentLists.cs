using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfDocumentLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "RfDocumentLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfDocumentLists_DocumentType",
                table: "RfDocumentLists",
                column: "DocumentType");

            migrationBuilder.AddForeignKey(
                name: "FK_RfDocumentLists_RfDocumentTypes_DocumentType",
                table: "RfDocumentLists",
                column: "DocumentType",
                principalTable: "RfDocumentTypes",
                principalColumn: "RfDocumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfDocumentLists_RfDocumentTypes_DocumentType",
                table: "RfDocumentLists");

            migrationBuilder.DropIndex(
                name: "IX_RfDocumentLists_DocumentType",
                table: "RfDocumentLists");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "RfDocumentLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
