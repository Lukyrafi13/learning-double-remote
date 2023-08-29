using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PropspectEditEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KodePos",
                table: "Prospects");

            migrationBuilder.AddColumn<int>(
                name: "RFZipCodeId",
                table: "Prospects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFZipCodeId",
                table: "Prospects",
                column: "RFZipCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeId",
                table: "Prospects",
                column: "RFZipCodeId",
                principalTable: "RFZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFZipCodes_RFZipCodeId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFZipCodeId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFZipCodeId",
                table: "Prospects");

            migrationBuilder.AddColumn<string>(
                name: "KodePos",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
