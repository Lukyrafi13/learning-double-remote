using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableDocumentAddColumnDocumentCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentCode",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentCode",
                table: "Documents",
                column: "DocumentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_RfDocumentLists_DocumentCode",
                table: "Documents",
                column: "DocumentCode",
                principalTable: "RfDocumentLists",
                principalColumn: "DocumentListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_RfDocumentLists_DocumentCode",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentCode",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentCode",
                table: "Documents");
        }
    }
}
