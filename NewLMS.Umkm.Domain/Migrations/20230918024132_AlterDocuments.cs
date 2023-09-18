using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentType",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentType",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DocumentType",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentType",
                table: "Documents",
                column: "DocumentType");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_RfParameterDetails_DocumentType",
                table: "Documents",
                column: "DocumentType",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
