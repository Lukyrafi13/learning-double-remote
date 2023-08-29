using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IntegrateSectorProspect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SektorEkonomi",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "SubSektorEkonomi",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "SubSubSektorEkonomi",
                table: "Prospects");

            migrationBuilder.AddColumn<string>(
                name: "RFSectorLBU1Code",
                table: "Prospects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFSectorLBU2Code",
                table: "Prospects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFSectorLBU3Code1",
                table: "Prospects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFSectorLBU1Code",
                table: "Prospects",
                column: "RFSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFSectorLBU2Code",
                table: "Prospects",
                column: "RFSectorLBU2Code");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFSectorLBU3Code1",
                table: "Prospects",
                column: "RFSectorLBU3Code1");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFSectorLBU1s_RFSectorLBU1Code",
                table: "Prospects",
                column: "RFSectorLBU1Code",
                principalTable: "RFSectorLBU1s",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFSectorLBU2s_RFSectorLBU2Code",
                table: "Prospects",
                column: "RFSectorLBU2Code",
                principalTable: "RFSectorLBU2s",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFSectorLBU3s_RFSectorLBU3Code1",
                table: "Prospects",
                column: "RFSectorLBU3Code1",
                principalTable: "RFSectorLBU3s",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFSectorLBU1s_RFSectorLBU1Code",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFSectorLBU2s_RFSectorLBU2Code",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFSectorLBU3s_RFSectorLBU3Code1",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFSectorLBU1Code",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFSectorLBU2Code",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFSectorLBU3Code1",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFSectorLBU1Code",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFSectorLBU2Code",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFSectorLBU3Code1",
                table: "Prospects");

            migrationBuilder.AddColumn<string>(
                name: "SektorEkonomi",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSektorEkonomi",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSubSektorEkonomi",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
