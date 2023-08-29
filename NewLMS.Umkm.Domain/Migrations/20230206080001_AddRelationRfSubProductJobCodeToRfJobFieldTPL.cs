using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddRelationRfSubProductJobCodeToRfJobFieldTPL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShowTpl",
                table: "RfSubProductJobCode",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RfSubProductJobCode_ShowTpl",
                table: "RfSubProductJobCode",
                column: "ShowTpl");

            migrationBuilder.AddForeignKey(
                name: "FK_RfSubProductJobCode_RfJobFieldTpls_ShowTpl",
                table: "RfSubProductJobCode",
                column: "ShowTpl",
                principalTable: "RfJobFieldTpls",
                principalColumn: "SHOW_TPL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfSubProductJobCode_RfJobFieldTpls_ShowTpl",
                table: "RfSubProductJobCode");

            migrationBuilder.DropIndex(
                name: "IX_RfSubProductJobCode_ShowTpl",
                table: "RfSubProductJobCode");

            migrationBuilder.AlterColumn<string>(
                name: "ShowTpl",
                table: "RfSubProductJobCode",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }
    }
}
