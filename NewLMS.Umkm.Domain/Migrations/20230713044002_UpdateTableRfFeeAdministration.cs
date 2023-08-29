using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class UpdateTableRfFeeAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Plafond",
                table: "RfFeeAdministrations",
                newName: "MinPlafond");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxPlafond",
                table: "RfFeeAdministrations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPlafond",
                table: "RfFeeAdministrations");

            migrationBuilder.RenameColumn(
                name: "MinPlafond",
                table: "RfFeeAdministrations",
                newName: "Plafond");
        }
    }
}
