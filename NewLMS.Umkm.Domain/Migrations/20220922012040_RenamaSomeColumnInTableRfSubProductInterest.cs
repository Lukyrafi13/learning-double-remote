using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class RenamaSomeColumnInTableRfSubProductInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntersetTopUp",
                table: "RfSubProductInterests",
                newName: "InterestTopUp");

            migrationBuilder.RenameColumn(
                name: "EndRate",
                table: "RfSubProductInterests",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterestTopUp",
                table: "RfSubProductInterests",
                newName: "IntersetTopUp");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "RfSubProductInterests",
                newName: "EndRate");
        }
    }
}
