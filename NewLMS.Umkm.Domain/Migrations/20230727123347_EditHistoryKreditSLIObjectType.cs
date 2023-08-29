using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditHistoryKreditSLIObjectType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SlikObjectTypeId",
                table: "SlikHistoryKredits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlikHistoryKredits_SlikObjectTypeId",
                table: "SlikHistoryKredits",
                column: "SlikObjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikHistoryKredits_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikHistoryKredits",
                column: "SlikObjectTypeId",
                principalTable: "SlikObjectTypes",
                principalColumn: "SlikObjectTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikHistoryKredits_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropIndex(
                name: "IX_SlikHistoryKredits_SlikObjectTypeId",
                table: "SlikHistoryKredits");

            migrationBuilder.DropColumn(
                name: "SlikObjectTypeId",
                table: "SlikHistoryKredits");
        }
    }
}
