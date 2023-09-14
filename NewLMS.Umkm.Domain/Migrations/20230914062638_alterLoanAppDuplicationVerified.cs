using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class alterLoanAppDuplicationVerified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanApplicationVerified",
                table: "LoanApplications");

            migrationBuilder.AddColumn<bool>(
                name: "DuplicationsVerified",
                table: "LoanApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuplicationsVerified",
                table: "LoanApplications");

            migrationBuilder.AddColumn<bool>(
                name: "LoanApplicationVerified",
                table: "LoanApplications",
                type: "bit",
                nullable: true);
        }
    }
}
