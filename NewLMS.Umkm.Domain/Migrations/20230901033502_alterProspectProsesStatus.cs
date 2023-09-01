using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterProspectProsesStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProspectStatus",
                table: "Prospects",
                newName: "ProcessStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessStatus",
                table: "Prospects",
                newName: "ProspectStatus");
        }
    }
}
