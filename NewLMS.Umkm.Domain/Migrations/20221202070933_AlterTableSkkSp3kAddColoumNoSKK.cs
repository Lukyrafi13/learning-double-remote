using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSkkSp3kAddColoumNoSKK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentSp3ks_FileUrls_FilesUrlFileUrlId",
                table: "DocumentSp3ks");

            migrationBuilder.DropIndex(
                name: "IX_DocumentSp3ks_FilesUrlFileUrlId",
                table: "DocumentSp3ks");

            migrationBuilder.DropColumn(
                name: "FilesUrlFileUrlId",
                table: "DocumentSp3ks");

            migrationBuilder.AddColumn<string>(
                name: "NoSKK",
                table: "SkkSp3ks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_DocumentSp3kUrl",
                table: "DocumentSp3ks",
                column: "DocumentSp3kUrl");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentSp3ks_FileUrls_DocumentSp3kUrl",
                table: "DocumentSp3ks",
                column: "DocumentSp3kUrl",
                principalTable: "FileUrls",
                principalColumn: "FileUrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentSp3ks_FileUrls_DocumentSp3kUrl",
                table: "DocumentSp3ks");

            migrationBuilder.DropIndex(
                name: "IX_DocumentSp3ks_DocumentSp3kUrl",
                table: "DocumentSp3ks");

            migrationBuilder.DropColumn(
                name: "NoSKK",
                table: "SkkSp3ks");

            migrationBuilder.AddColumn<Guid>(
                name: "FilesUrlFileUrlId",
                table: "DocumentSp3ks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_FilesUrlFileUrlId",
                table: "DocumentSp3ks",
                column: "FilesUrlFileUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentSp3ks_FileUrls_FilesUrlFileUrlId",
                table: "DocumentSp3ks",
                column: "FilesUrlFileUrlId",
                principalTable: "FileUrls",
                principalColumn: "FileUrlId");
        }
    }
}
