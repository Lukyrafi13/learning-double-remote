using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class UpdateColumnKeyInTableRfJobGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfJobGrades",
                table: "RfJobGrades");

            migrationBuilder.AlterColumn<string>(
                name: "JobPosition",
                table: "RfJobGrades",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfJobGrades",
                table: "RfJobGrades",
                columns: new[] { "GradeCode", "JobPosition" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfJobGrades",
                table: "RfJobGrades");

            migrationBuilder.AlterColumn<string>(
                name: "JobPosition",
                table: "RfJobGrades",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfJobGrades",
                table: "RfJobGrades",
                column: "GradeCode");
        }
    }
}
