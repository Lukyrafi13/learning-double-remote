using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SiklusUsahaRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResiGudang",
                table: "RFSiklusUsahas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MCount",
                table: "RFSiklusUsahas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResiGudang",
                table: "RFSiklusUsahas");

            migrationBuilder.DropColumn(
                name: "MCount",
                table: "RFSiklusUsahas");
        }
    }
}
