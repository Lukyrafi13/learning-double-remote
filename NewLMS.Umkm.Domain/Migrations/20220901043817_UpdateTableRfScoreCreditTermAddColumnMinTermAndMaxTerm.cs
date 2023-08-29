using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class UpdateTableRfScoreCreditTermAddColumnMinTermAndMaxTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxTerm",
                table: "RfScoringCreditTerms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinTerm",
                table: "RfScoringCreditTerms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTerm",
                table: "RfScoringCreditTerms");

            migrationBuilder.DropColumn(
                name: "MinTerm",
                table: "RfScoringCreditTerms");
        }
    }
}
