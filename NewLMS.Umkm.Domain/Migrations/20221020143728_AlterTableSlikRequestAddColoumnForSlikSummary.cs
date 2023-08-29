using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSlikRequestAddColoumnForSlikSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminVerified",
                table: "SLIKRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "SLIKRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalCreditCard",
                table: "SLIKRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLimitSlik",
                table: "SLIKRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalOtherUsers",
                table: "SLIKRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalWorkingCapital",
                table: "SLIKRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminVerified",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "TotalCreditCard",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "TotalLimitSlik",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "TotalOtherUsers",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "TotalWorkingCapital",
                table: "SLIKRequests");
        }
    }
}
