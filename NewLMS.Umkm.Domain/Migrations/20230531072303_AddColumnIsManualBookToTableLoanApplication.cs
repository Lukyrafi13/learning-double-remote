using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddColumnIsManualBookToTableLoanApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManualBook",
                table: "LoanApplications",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManualBook",
                table: "LoanApplications");
        }
    }
}
