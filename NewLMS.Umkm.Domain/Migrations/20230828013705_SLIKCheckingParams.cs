using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKCheckingParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckingErrorMessage",
                table: "SlikRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckingError",
                table: "SlikRequests",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckingErrorMessage",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "IsCheckingError",
                table: "SlikRequests");
        }
    }
}
