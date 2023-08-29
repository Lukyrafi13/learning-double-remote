using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKRequestEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikRequestObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikRequestObjects_SlikRequests_SlikRequestGuid",
                table: "SlikRequestObjects");

            migrationBuilder.RenameColumn(
                name: "SlikRequestGuid",
                table: "SlikRequestObjects",
                newName: "SlikRequestId");

            migrationBuilder.RenameColumn(
                name: "SlikRequestObjectGuid",
                table: "SlikRequestObjects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SlikRequestObjects_SlikRequestGuid",
                table: "SlikRequestObjects",
                newName: "IX_SlikRequestObjects_SlikRequestId");

            migrationBuilder.AlterColumn<int>(
                name: "SlikObjectTypeId",
                table: "SlikRequestObjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikRequestObjects",
                column: "SlikObjectTypeId",
                principalTable: "SlikObjectTypes",
                principalColumn: "SlikObjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlikRequestObjects_SlikRequests_SlikRequestId",
                table: "SlikRequestObjects",
                column: "SlikRequestId",
                principalTable: "SlikRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikRequestObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SlikRequestObjects_SlikRequests_SlikRequestId",
                table: "SlikRequestObjects");

            migrationBuilder.RenameColumn(
                name: "SlikRequestId",
                table: "SlikRequestObjects",
                newName: "SlikRequestGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SlikRequestObjects",
                newName: "SlikRequestObjectGuid");

            migrationBuilder.RenameIndex(
                name: "IX_SlikRequestObjects_SlikRequestId",
                table: "SlikRequestObjects",
                newName: "IX_SlikRequestObjects_SlikRequestGuid");

            migrationBuilder.AlterColumn<int>(
                name: "SlikObjectTypeId",
                table: "SlikRequestObjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                table: "SlikRequestObjects",
                column: "SlikObjectTypeId",
                principalTable: "SlikObjectTypes",
                principalColumn: "SlikObjectTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SlikRequestObjects_SlikRequests_SlikRequestGuid",
                table: "SlikRequestObjects",
                column: "SlikRequestGuid",
                principalTable: "SlikRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
