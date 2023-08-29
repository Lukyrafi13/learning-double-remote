using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RepairIDEEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RFSubProducts_RFProducts_ProductId1",
                table: "RFSubProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_RFTenorMappings_RFProducts_ProductId1",
                table: "RFTenorMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_RFTenors_RFProducts_ProductId1",
                table: "RFTenors");

            migrationBuilder.DropIndex(
                name: "IX_RFTenors_ProductId1",
                table: "RFTenors");

            migrationBuilder.DropIndex(
                name: "IX_RFTenorMappings_ProductId1",
                table: "RFTenorMappings");

            migrationBuilder.DropIndex(
                name: "IX_RFSubProducts_ProductId1",
                table: "RFSubProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "RFTenors");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "RFTenorMappings");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "RFSubProducts");

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

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFSubProducts",
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

            migrationBuilder.CreateIndex(
                name: "IX_RFSubProducts_ProductId",
                table: "RFSubProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFSubProducts_RFProducts_ProductId",
                table: "RFSubProducts",
                column: "ProductId",
                principalTable: "RFProducts",
                principalColumn: "ProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RFSubProducts_RFProducts_ProductId",
                table: "RFSubProducts");

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

            migrationBuilder.DropIndex(
                name: "IX_RFSubProducts_ProductId",
                table: "RFSubProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "RFTenors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFTenorMappings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "RFTenorMappings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFSubProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "RFSubProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFTenors_ProductId1",
                table: "RFTenors",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RFTenorMappings_ProductId1",
                table: "RFTenorMappings",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RFSubProducts_ProductId1",
                table: "RFSubProducts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RFSubProducts_RFProducts_ProductId1",
                table: "RFSubProducts",
                column: "ProductId1",
                principalTable: "RFProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFTenorMappings_RFProducts_ProductId1",
                table: "RFTenorMappings",
                column: "ProductId1",
                principalTable: "RFProducts",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RFTenors_RFProducts_ProductId1",
                table: "RFTenors",
                column: "ProductId1",
                principalTable: "RFProducts",
                principalColumn: "ProductId");
        }
    }
}
