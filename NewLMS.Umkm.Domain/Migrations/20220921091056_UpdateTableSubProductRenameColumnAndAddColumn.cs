using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class UpdateTableSubProductRenameColumnAndAddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GracePeriod",
                table: "RfSubProducts",
                newName: "GradePeriodPension");

            migrationBuilder.AddColumn<bool>(
                name: "IsGradePeriod",
                table: "RfSubProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGradePeriod",
                table: "RfSubProducts");

            migrationBuilder.RenameColumn(
                name: "GradePeriodPension",
                table: "RfSubProducts",
                newName: "GracePeriod");
        }
    }
}
