using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableProspectAddFKBookingBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookingBranch",
                table: "Prospects",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_BookingBranch",
                table: "Prospects",
                column: "BookingBranch");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfBranches_BookingBranch",
                table: "Prospects",
                column: "BookingBranch",
                principalTable: "RfBranches",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfBranches_BookingBranch",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_BookingBranch",
                table: "Prospects");

            migrationBuilder.AlterColumn<string>(
                name: "BookingBranch",
                table: "Prospects",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);
        }
    }
}
