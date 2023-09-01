using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterProspectProspectStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProspectStatus",
                table: "Prospects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProspectStatus",
                table: "Prospects");
        }
    }
}
