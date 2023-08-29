using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SPPKChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPPKFileUploads_SPPKs_SPPKId",
                table: "SPPKFileUploads");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SPPKFileUploads");

            migrationBuilder.AlterColumn<Guid>(
                name: "SPPKId",
                table: "SPPKFileUploads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKFileUploads_SPPKs_SPPKId",
                table: "SPPKFileUploads",
                column: "SPPKId",
                principalTable: "SPPKs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPPKFileUploads_SPPKs_SPPKId",
                table: "SPPKFileUploads");

            migrationBuilder.AlterColumn<Guid>(
                name: "SPPKId",
                table: "SPPKFileUploads",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "SPPKFileUploads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_SPPKFileUploads_SPPKs_SPPKId",
                table: "SPPKFileUploads",
                column: "SPPKId",
                principalTable: "SPPKs",
                principalColumn: "Id");
        }
    }
}
