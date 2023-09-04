using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterRfVehMakerrfVehClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollateralCode",
                table: "RfVehMakers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehMakerCode",
                table: "RfVehClasss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfVehMakers_CollateralCode",
                table: "RfVehMakers",
                column: "CollateralCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfVehClasss_VehMakerCode",
                table: "RfVehClasss",
                column: "VehMakerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RfVehClasss_RfVehMakers_VehMakerCode",
                table: "RfVehClasss",
                column: "VehMakerCode",
                principalTable: "RfVehMakers",
                principalColumn: "VehMakerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_RfVehMakers_RfCollateralBCs_CollateralCode",
                table: "RfVehMakers",
                column: "CollateralCode",
                principalTable: "RfCollateralBCs",
                principalColumn: "CollateralCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfVehClasss_RfVehMakers_VehMakerCode",
                table: "RfVehClasss");

            migrationBuilder.DropForeignKey(
                name: "FK_RfVehMakers_RfCollateralBCs_CollateralCode",
                table: "RfVehMakers");

            migrationBuilder.DropIndex(
                name: "IX_RfVehMakers_CollateralCode",
                table: "RfVehMakers");

            migrationBuilder.DropIndex(
                name: "IX_RfVehClasss_VehMakerCode",
                table: "RfVehClasss");

            migrationBuilder.DropColumn(
                name: "CollateralCode",
                table: "RfVehMakers");

            migrationBuilder.DropColumn(
                name: "VehMakerCode",
                table: "RfVehClasss");
        }
    }
}
