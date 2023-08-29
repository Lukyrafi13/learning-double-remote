using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyCSBP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CSBPDetailDesc",
                table: "RFCSBPHeaders");

            migrationBuilder.RenameColumn(
                name: "CSBPGrupID",
                table: "RFCSBPHeaders",
                newName: "CSBPGroupName");

            migrationBuilder.RenameColumn(
                name: "CSBPDetailNama",
                table: "RFCSBPHeaders",
                newName: "CSBPGroupID");

            migrationBuilder.RenameColumn(
                name: "CSBPDetailID",
                table: "RFCSBPHeaders",
                newName: "CSBPGroupDesc");

            migrationBuilder.RenameColumn(
                name: "CSBPGrupID",
                table: "RFCSBPDetails",
                newName: "CSBPGroupID");

            migrationBuilder.RenameColumn(
                name: "CSBPDetailNama",
                table: "RFCSBPDetails",
                newName: "CSBPDetailName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CSBPGroupName",
                table: "RFCSBPHeaders",
                newName: "CSBPGrupID");

            migrationBuilder.RenameColumn(
                name: "CSBPGroupID",
                table: "RFCSBPHeaders",
                newName: "CSBPDetailNama");

            migrationBuilder.RenameColumn(
                name: "CSBPGroupDesc",
                table: "RFCSBPHeaders",
                newName: "CSBPDetailID");

            migrationBuilder.RenameColumn(
                name: "CSBPGroupID",
                table: "RFCSBPDetails",
                newName: "CSBPGrupID");

            migrationBuilder.RenameColumn(
                name: "CSBPDetailName",
                table: "RFCSBPDetails",
                newName: "CSBPDetailNama");

            migrationBuilder.AddColumn<string>(
                name: "CSBPDetailDesc",
                table: "RFCSBPHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
