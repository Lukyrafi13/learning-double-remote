using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKCheckingParamsModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckingDuplikasi",
                table: "SlikRequests");

            migrationBuilder.AddColumn<int>(
                name: "StatusCheckingDuplikasi",
                table: "SlikRequests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCheckingDuplikasi",
                table: "SlikRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckingDuplikasi",
                table: "SlikRequests",
                type: "bit",
                nullable: true);
        }
    }
}
