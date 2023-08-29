using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableSCJabatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SCJabatans",
                table: "SCJabatans");

            migrationBuilder.DropColumn(
                name: "SCJabatanId",
                table: "SCJabatans");

            migrationBuilder.AlterColumn<string>(
                name: "JabCode",
                table: "SCJabatans",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCJabatans",
                table: "SCJabatans",
                column: "JabCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SCJabatans",
                table: "SCJabatans");

            migrationBuilder.AlterColumn<string>(
                name: "JabCode",
                table: "SCJabatans",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<Guid>(
                name: "SCJabatanId",
                table: "SCJabatans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SCJabatans",
                table: "SCJabatans",
                column: "SCJabatanId");
        }
    }
}
