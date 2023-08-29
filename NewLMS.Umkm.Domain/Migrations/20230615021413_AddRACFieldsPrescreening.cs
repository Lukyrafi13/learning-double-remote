using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddRACFieldsPrescreening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PesertaBPJSTK",
                table: "Prescreenings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TidakPernahMenerimaKredit",
                table: "Prescreenings",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesertaBPJSTK",
                table: "Prescreenings");

            migrationBuilder.DropColumn(
                name: "TidakPernahMenerimaKredit",
                table: "Prescreenings");
        }
    }
}
