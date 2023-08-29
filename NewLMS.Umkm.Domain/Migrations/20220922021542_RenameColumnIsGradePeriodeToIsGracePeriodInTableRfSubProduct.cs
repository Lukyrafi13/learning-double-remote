using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class RenameColumnIsGradePeriodeToIsGracePeriodInTableRfSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsGradePeriod",
                table: "RfSubProducts",
                newName: "IsGracePeriod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsGracePeriod",
                table: "RfSubProducts",
                newName: "IsGradePeriod");
        }
    }
}
