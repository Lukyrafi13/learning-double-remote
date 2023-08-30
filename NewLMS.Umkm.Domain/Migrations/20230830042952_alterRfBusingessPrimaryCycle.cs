using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterRfBusingessPrimaryCycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CyclusDesc",
                table: "RfBusinessPrimaryCycles",
                newName: "CycleDesc");

            migrationBuilder.RenameColumn(
                name: "CyclusCode",
                table: "RfBusinessPrimaryCycles",
                newName: "CycleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CycleDesc",
                table: "RfBusinessPrimaryCycles",
                newName: "CyclusDesc");

            migrationBuilder.RenameColumn(
                name: "CycleCode",
                table: "RfBusinessPrimaryCycles",
                newName: "CyclusCode");
        }
    }
}
