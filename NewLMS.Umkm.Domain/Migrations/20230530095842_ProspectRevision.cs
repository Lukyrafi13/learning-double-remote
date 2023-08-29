using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ProspectRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RFZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AlamatTempat",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JenisUsahaLain",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KabupatenKotaTempat",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KecamatanTempat",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KelurahanTempat",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropinsiTempat",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeTempatId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFZipCodeTempatId",
                table: "Prospects",
                column: "RFZipCodeTempatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeTempatId",
                table: "Prospects",
                column: "RFZipCodeTempatId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeTempatId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFZipCodeTempatId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "AlamatTempat",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "JenisUsahaLain",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KabupatenKotaTempat",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KecamatanTempat",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "KelurahanTempat",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "PropinsiTempat",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFZipCodeTempatId",
                table: "Prospects");

            migrationBuilder.AlterColumn<int>(
                name: "RFZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
