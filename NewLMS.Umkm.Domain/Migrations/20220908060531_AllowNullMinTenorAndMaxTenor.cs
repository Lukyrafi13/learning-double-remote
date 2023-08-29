using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AllowNullMinTenorAndMaxTenor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfRates_RfSubProducts_SubProductId",
                table: "RfRates");

            migrationBuilder.AlterColumn<string>(
                name: "SubProductId",
                table: "RfRates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinTenor",
                table: "RfRates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxTenor",
                table: "RfRates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RfRates_RfSubProducts_SubProductId",
                table: "RfRates",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfRates_RfSubProducts_SubProductId",
                table: "RfRates");

            migrationBuilder.AlterColumn<string>(
                name: "SubProductId",
                table: "RfRates",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "MinTenor",
                table: "RfRates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxTenor",
                table: "RfRates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RfRates_RfSubProducts_SubProductId",
                table: "RfRates",
                column: "SubProductId",
                principalTable: "RfSubProducts",
                principalColumn: "SubProductId");
        }
    }
}
