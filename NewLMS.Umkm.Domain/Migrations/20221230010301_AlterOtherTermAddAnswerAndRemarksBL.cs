using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterOtherTermAddAnswerAndRemarksBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Answer",
                table: "OtherTerms",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Remarks",
                table: "OtherTerms",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "OtherTerms");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "OtherTerms");
        }
    }
}
