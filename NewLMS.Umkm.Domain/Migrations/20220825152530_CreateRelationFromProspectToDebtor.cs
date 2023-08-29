using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateRelationFromProspectToDebtor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Prospects_NoIdentity",
                table: "Prospects",
                column: "NoIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_Debtors_NoIdentity",
                table: "Prospects",
                column: "NoIdentity",
                principalTable: "Debtors",
                principalColumn: "NoIdentity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_Debtors_NoIdentity",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_NoIdentity",
                table: "Prospects");
        }
    }
}
