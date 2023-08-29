using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class UpdateTableRfJobPensiunTPL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaxTermOfOffice",
                table: "RfJobPensiunTpls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "RfJobPensiunTpls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RfJobPensiunTpls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "RfJobPensiunTpls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "RfJobPensiunTpls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "RfJobPensiunTpls",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RfJobPensiunTpls",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RfJobPensiunTpls");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RfJobPensiunTpls");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RfJobPensiunTpls");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "RfJobPensiunTpls");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RfJobPensiunTpls");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RfJobPensiunTpls");

            migrationBuilder.AlterColumn<int>(
                name: "MaxTermOfOffice",
                table: "RfJobPensiunTpls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
