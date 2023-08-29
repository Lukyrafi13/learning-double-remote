using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EditEntityRfBranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RfBranches");

            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "RfBranches");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "RfBranches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "RfBranches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RfBranches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "ACTIVE",
                table: "RfBranches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfBranches",
                table: "RfBranches",
                column: "Id");
        }
    }
}
