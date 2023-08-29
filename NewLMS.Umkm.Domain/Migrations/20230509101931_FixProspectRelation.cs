using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class FixProspectRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFGenders_RFKodeDinasId",
                table: "Prospects");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFKodeDinass_RFKodeDinasId",
                table: "Prospects",
                column: "RFKodeDinasId",
                principalTable: "RFKodeDinass",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFKodeDinass_RFKodeDinasId",
                table: "Prospects");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFGenders_RFKodeDinasId",
                table: "Prospects",
                column: "RFKodeDinasId",
                principalTable: "RFGenders",
                principalColumn: "Id");
        }
    }
}
