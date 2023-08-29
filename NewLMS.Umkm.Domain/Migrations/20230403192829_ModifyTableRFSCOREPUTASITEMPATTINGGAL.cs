using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyTableRFSCOREPUTASITEMPATTINGGAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFReputationAddress",
                table: "RFReputationAddress");

            migrationBuilder.RenameTable(
                name: "RFReputationAddress",
                newName: "RFSCOREPUTASITEMPATTINGGAL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFSCOREPUTASITEMPATTINGGAL",
                table: "RFSCOREPUTASITEMPATTINGGAL",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFSCOREPUTASITEMPATTINGGAL",
                table: "RFSCOREPUTASITEMPATTINGGAL");

            migrationBuilder.RenameTable(
                name: "RFSCOREPUTASITEMPATTINGGAL",
                newName: "RFReputationAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFReputationAddress",
                table: "RFReputationAddress",
                column: "Id");
        }
    }
}
