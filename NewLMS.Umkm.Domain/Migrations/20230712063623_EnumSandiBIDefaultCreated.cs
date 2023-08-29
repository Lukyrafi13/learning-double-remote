using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class EnumSandiBIDefaultCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RFSANDIBIS",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RFSANDIBIS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EnumSandiBITypes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "EnumSandiBITypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EnumSandiBIGroups",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "EnumSandiBIGroups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RFSANDIBIS",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RFSANDIBIS",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EnumSandiBITypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "EnumSandiBITypes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "EnumSandiBIGroups",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "EnumSandiBIGroups",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"));
        }
    }
}
