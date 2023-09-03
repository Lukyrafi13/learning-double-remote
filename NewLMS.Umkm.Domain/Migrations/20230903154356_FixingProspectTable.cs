using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class FixingProspectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfZipCodes_ZipCodeId",
                table: "Prospects");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "SameAsIdentity",
                table: "Prospects",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                table: "Prospects",
                column: "PlaceZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfZipCodes_ZipCodeId",
                table: "Prospects",
                column: "ZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfZipCodes_ZipCodeId",
                table: "Prospects");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SameAsIdentity",
                table: "Prospects",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfZipCodes_PlaceZipCodeId",
                table: "Prospects",
                column: "PlaceZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfZipCodes_ZipCodeId",
                table: "Prospects",
                column: "ZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
