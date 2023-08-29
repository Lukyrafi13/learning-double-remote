using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDocumentSp3kRemoveProductIdAddProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentSp3ks_RfProducts_ProductId",
                table: "DocumentSp3ks");

            migrationBuilder.DropIndex(
                name: "IX_DocumentSp3ks_ProductId",
                table: "DocumentSp3ks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DocumentSp3ks");

            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "DocumentSp3ks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "DocumentSp3ks");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "DocumentSp3ks",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_ProductId",
                table: "DocumentSp3ks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentSp3ks_RfProducts_ProductId",
                table: "DocumentSp3ks",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");
        }
    }
}
