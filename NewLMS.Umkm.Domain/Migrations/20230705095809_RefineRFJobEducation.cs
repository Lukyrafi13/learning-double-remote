using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RefineRFJobEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CORE_CODE",
                table: "RFJOB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ED_CODESIKP",
                table: "RFEDUCATION",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ED_DESCSIKP",
                table: "RFEDUCATION",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ED_CODESIKP",
                table: "RFEDUCATION");

            migrationBuilder.DropColumn(
                name: "ED_DESCSIKP",
                table: "RFEDUCATION");

            migrationBuilder.AlterColumn<int>(
                name: "CORE_CODE",
                table: "RFJOB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
