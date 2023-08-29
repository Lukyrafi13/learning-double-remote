using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AttrValidMessageCalonDebitur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageValidasi",
                table: "SIKPCalonDebiturs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "SIKPCalonDebiturs",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageValidasi",
                table: "SIKPCalonDebiturs");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "SIKPCalonDebiturs");
        }
    }
}
