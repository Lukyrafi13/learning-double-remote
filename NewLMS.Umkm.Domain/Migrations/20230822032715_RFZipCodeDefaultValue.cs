using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFZipCodeDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NilaiPertanggungan",
                table: "Analisas");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RFZipCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RFZipCodes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RFZipCodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "RFZipCodes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RFZipCodes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "RFZipCodes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465"));

            migrationBuilder.AddColumn<double>(
                name: "NilaiPertanggungan",
                table: "Analisas",
                type: "float",
                nullable: true);
        }
    }
}
