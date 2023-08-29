using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfSandiBis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropPrimaryKey(
               name: "PK_RfSandiBIs",
               table: "RfSandiBIs");

            migrationBuilder.AlterColumn<string>(
                name: "RfSandiBIId",
                table: "RfSandiBIs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSandiBIs",
                table: "RfSandiBIs",
                column: "RfSandiBIId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
               name: "PK_RfSandiBIs",
               table: "RfSandiBIs");

            migrationBuilder.AlterColumn<Guid>(
                name: "RfSandiBIId",
                table: "RfSandiBIs",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
             name: "PK_RfSandiBIs",
             table: "RfSandiBIs",
             column: "RfSandiBIId");
        }
    }
}
