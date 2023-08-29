using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfDocumentListDropFKSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfDocumentLists_RfSubProducts_SubProductId",
                table: "RfDocumentLists");

            migrationBuilder.DropIndex(
                name: "IX_RfDocumentLists_SubProductId",
                table: "RfDocumentLists");

            migrationBuilder.AlterColumn<string>(
                name: "SubProductId",
                table: "RfDocumentLists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubProductId",
                table: "RfDocumentLists",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfDocumentLists_SubProductId",
                table: "RfDocumentLists",
                column: "SubProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfDocumentLists_RfSubProducts_SubProductId",
                table: "RfDocumentLists",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }
    }
}
