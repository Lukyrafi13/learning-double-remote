using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSlikRequestDeptorUpdateSLIKDocumentUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequests_FileUrls_SLIKDocumentURL",
                table: "SLIKRequests");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequests_SLIKDocumentURL",
                table: "SLIKRequests");

            migrationBuilder.DropColumn(
                name: "SLIKDocumentURL",
                table: "SLIKRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "SLIKDocumentUrl",
                table: "SLIKRequestDebtors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKDocumentUrl",
                table: "SLIKRequestDebtors",
                column: "SLIKDocumentUrl");

            migrationBuilder.AddForeignKey(
                name: "FK_SLIKRequestDebtors_FileUrls_SLIKDocumentUrl",
                table: "SLIKRequestDebtors",
                column: "SLIKDocumentUrl",
                principalTable: "FileUrls",
                principalColumn: "FileUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SLIKRequestDebtors_FileUrls_SLIKDocumentUrl",
                table: "SLIKRequestDebtors");

            migrationBuilder.DropIndex(
                name: "IX_SLIKRequestDebtors_SLIKDocumentUrl",
                table: "SLIKRequestDebtors");

            migrationBuilder.AddColumn<Guid>(
                name: "SLIKDocumentURL",
                table: "SLIKRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "SLIKDocumentUrl",
                table: "SLIKRequestDebtors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
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
                principalColumn: "FileUrlId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
