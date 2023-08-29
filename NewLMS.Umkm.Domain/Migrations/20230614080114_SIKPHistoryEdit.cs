using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SIKPHistoryEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Plafond",
                table: "SIKPHistorys",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFSectorLBU3Code",
                table: "SIKPHistorys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIKPHistorys_RFSectorLBU3Code",
                table: "SIKPHistorys",
                column: "RFSectorLBU3Code");

            migrationBuilder.AddForeignKey(
                name: "FK_SIKPHistorys_RFSectorLBU3s_RFSectorLBU3Code",
                table: "SIKPHistorys",
                column: "RFSectorLBU3Code",
                principalTable: "RFSectorLBU3s",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIKPHistorys_RFSectorLBU3s_RFSectorLBU3Code",
                table: "SIKPHistorys");

            migrationBuilder.DropIndex(
                name: "IX_SIKPHistorys_RFSectorLBU3Code",
                table: "SIKPHistorys");

            migrationBuilder.DropColumn(
                name: "Plafond",
                table: "SIKPHistorys");

            migrationBuilder.DropColumn(
                name: "RFSectorLBU3Code",
                table: "SIKPHistorys");
        }
    }
}
