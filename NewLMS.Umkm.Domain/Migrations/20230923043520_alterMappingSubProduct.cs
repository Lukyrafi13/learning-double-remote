using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterMappingSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "RfMappingSubProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingSubProducts_ProductId",
                table: "RfMappingSubProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfMappingSubProducts_RfProducts_ProductId",
                table: "RfMappingSubProducts",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfMappingSubProducts_RfProducts_ProductId",
                table: "RfMappingSubProducts");

            migrationBuilder.DropIndex(
                name: "IX_RfMappingSubProducts_ProductId",
                table: "RfMappingSubProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RfMappingSubProducts");
        }
    }
}
