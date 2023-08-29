using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnsTgalAwalKontrakTglAkhirKontrakTableRfJobFieldTpls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TGLAKHIRKONTRAK",
                table: "RfJobFieldTpls",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TGLAWALKONTRAK",
                table: "RfJobFieldTpls",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TGLAKHIRKONTRAK",
                table: "RfJobFieldTpls");

            migrationBuilder.DropColumn(
                name: "TGLAWALKONTRAK",
                table: "RfJobFieldTpls");
        }
    }
}
