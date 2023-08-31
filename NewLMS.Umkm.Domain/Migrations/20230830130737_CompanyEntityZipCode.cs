using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class CompanyEntityZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfZipCodeId",
                table: "CompanyEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfZipCodeId",
                table: "CompanyEntities",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfZipCodeId",
                table: "CompanyEntities");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEntities_RfZipCodes_RfZipCodeId",
                table: "CompanyEntities",
                column: "RfZipCodeId",
                principalTable: "RfZipCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
