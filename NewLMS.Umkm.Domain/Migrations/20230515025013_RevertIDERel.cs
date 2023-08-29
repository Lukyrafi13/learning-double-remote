using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RevertIDERel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RFTenorMappings_RFProducts_ProductId",
                table: "RFTenorMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_RFTenors_RFProducts_ProductId",
                table: "RFTenors");

            migrationBuilder.DropIndex(
                name: "IX_RFTenors_ProductId",
                table: "RFTenors");

            migrationBuilder.DropIndex(
                name: "IX_RFTenorMappings_ProductId",
                table: "RFTenorMappings");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenorMappings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenorMappings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFTenors_ProductId",
                table: "RFTenors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RFTenorMappings_ProductId",
                table: "RFTenorMappings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFTenorMappings_RFProducts_ProductId",
                table: "RFTenorMappings",
                column: "ProductId",
                principalTable: "RFProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFTenors_RFProducts_ProductId",
                table: "RFTenors",
                column: "ProductId",
                principalTable: "RFProducts",
                principalColumn: "ProductId");
        }
    }
}
