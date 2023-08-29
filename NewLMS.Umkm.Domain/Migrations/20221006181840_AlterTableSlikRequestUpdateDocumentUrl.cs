using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSlikRequestUpdateDocumentUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SLIKDocumentURL",
                table: "SLIKRequests",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequests_SLIKDocumentURL",
                table: "SLIKRequests",
                column: "SLIKDocumentURL");

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequests_FileUrls_SLIKDocumentURL",
                table: "SLIKRequests",
                column: "SLIKDocumentURL",
                principalTable: "FileUrls",
                principalColumn: "FileUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_FileUrls_SLIKDocumentURL",
                table: "SLIKRequests");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequests_SLIKDocumentURL",
                table: "SLIKRequests");

            migrationBuilder.AlterColumn<string>(
                name: "SLIKDocumentURL",
                table: "SLIKRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
