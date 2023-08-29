using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class FixingColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LimitUser",
                table: "ScUserDetails",
                type: "Float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "LimitUser",
                table: "ScUserDetails",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "Float",
                oldNullable: true);
        }
    }
}
