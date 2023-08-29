using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditSlikRequestEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCreditCard",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "TotalLimitSlik",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "TotalOtheUsers",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "TotalWorkingCapital",
                table: "SlikRequests");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "SlikRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MembacaDanMemahami",
                table: "SlikRequests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BelumMemilikiSLIK",
                table: "SlikRequestObjects",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "MembacaDanMemahami",
                table: "SlikRequests");

            migrationBuilder.DropColumn(
                name: "BelumMemilikiSLIK",
                table: "SlikRequestObjects");

            migrationBuilder.AddColumn<int>(
                name: "TotalCreditCard",
                table: "SlikRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLimitSlik",
                table: "SlikRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalOtheUsers",
                table: "SlikRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalWorkingCapital",
                table: "SlikRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
