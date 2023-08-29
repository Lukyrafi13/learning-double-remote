using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AlterTableRfSandiBIandRfSandiBIGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfSandBIs_RfSandiBIGroups_RfSandiBIGroupId",
                table: "RfSandBIs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfSandiBIGroups",
                table: "RfSandiBIGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfSandBIs",
                table: "RfSandBIs");

            migrationBuilder.DropIndex(
                name: "IX_RfSandBIs_RfSandiBIGroupId",
                table: "RfSandBIs");

            migrationBuilder.DropColumn(
                name: "RfSandiBIGroupId",
                table: "RfSandiBIGroups");

            migrationBuilder.DropColumn(
                name: "RfSandiBIGroupId",
                table: "RfSandBIs");

            migrationBuilder.RenameTable(
                name: "RfSandBIs",
                newName: "RfSandiBIs");

            migrationBuilder.AlterColumn<string>(
                name: "BIDesc",
                table: "RfSandiBIGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "BIGroup",
                table: "RfSandiBIGroups",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "CoreCode",
                table: "RfSandiBIs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "RfSandiBIs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "BIType",
                table: "RfSandiBIs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "BIDesc",
                table: "RfSandiBIs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "BICode",
                table: "RfSandiBIs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "RfSandiBIs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "RfSandiBIId",
                table: "RfSandiBIs",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 20)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<string>(
                name: "BIGroup",
                table: "RfSandiBIs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSandiBIGroups",
                table: "RfSandiBIGroups",
                column: "BIGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSandiBIs",
                table: "RfSandiBIs",
                column: "RfSandiBIId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSandiBIs_BIGroup",
                table: "RfSandiBIs",
                column: "BIGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_RfSandiBIs_RfSandiBIGroups_BIGroup",
                table: "RfSandiBIs",
                column: "BIGroup",
                principalTable: "RfSandiBIGroups",
                principalColumn: "BIGroup",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfSandiBIs_RfSandiBIGroups_BIGroup",
                table: "RfSandiBIs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfSandiBIGroups",
                table: "RfSandiBIGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfSandiBIs",
                table: "RfSandiBIs");

            migrationBuilder.DropIndex(
                name: "IX_RfSandiBIs_BIGroup",
                table: "RfSandiBIs");

            migrationBuilder.DropColumn(
                name: "BIGroup",
                table: "RfSandiBIGroups");

            migrationBuilder.DropColumn(
                name: "BIGroup",
                table: "RfSandiBIs");

            migrationBuilder.RenameTable(
                name: "RfSandiBIs",
                newName: "RfSandBIs");

            migrationBuilder.AlterColumn<string>(
                name: "BIDesc",
                table: "RfSandiBIGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<Guid>(
                name: "RfSandiBIGroupId",
                table: "RfSandiBIGroups",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "CoreCode",
                table: "RfSandBIs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "RfSandBIs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "BIType",
                table: "RfSandBIs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "BIDesc",
                table: "RfSandBIs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "BICode",
                table: "RfSandBIs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "RfSandBIs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "RfSandiBIId",
                table: "RfSandBIs",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 20)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RfSandiBIGroupId",
                table: "RfSandBIs",
                type: "uniqueidentifier",
                maxLength: 20,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSandiBIGroups",
                table: "RfSandiBIGroups",
                column: "RfSandiBIGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfSandBIs",
                table: "RfSandBIs",
                column: "RfSandiBIId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSandBIs_RfSandiBIGroupId",
                table: "RfSandBIs",
                column: "RfSandiBIGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfSandBIs_RfSandiBIGroups_RfSandiBIGroupId",
                table: "RfSandBIs",
                column: "RfSandiBIGroupId",
                principalTable: "RfSandiBIGroups",
                principalColumn: "RfSandiBIGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
