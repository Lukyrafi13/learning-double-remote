using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterInstalmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfInstalmentTypes_RfProducts_ProductId",
                table: "RfInstalmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_RfInstalmentTypes_ProductId",
                table: "RfInstalmentTypes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RfInstalmentTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "RfInstalmentTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfInstalmentTypes_ProductId",
                table: "RfInstalmentTypes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfInstalmentTypes_RfProducts_ProductId",
                table: "RfInstalmentTypes",
                column: "ProductId",
                principalTable: "RfProducts",
                principalColumn: "ProductId");
        }
    }
}
