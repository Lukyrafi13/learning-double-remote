using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class ModifyMarital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFMARITAL",
                table: "RFMARITAL");

            migrationBuilder.RenameTable(
                name: "RFMARITAL",
                newName: "RFMARITALs");

            migrationBuilder.RenameColumn(
                name: "MaritalStatusName",
                table: "RFMARITALs",
                newName: "MR_DESCSIKP");

            migrationBuilder.RenameColumn(
                name: "MaritalStatusId",
                table: "RFMARITALs",
                newName: "WITHSPOUSE");

            migrationBuilder.AlterColumn<string>(
                name: "PRODUCTID",
                table: "RFJOB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CORE_CODE",
                table: "RFJOB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JOB_CODE",
                table: "RFJOB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ACTIVE",
                table: "RFMARITALs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CORE_CODE",
                table: "RFMARITALs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MR_CODE",
                table: "RFMARITALs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MR_CODESIKP",
                table: "RFMARITALs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MR_DESC",
                table: "RFMARITALs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFMARITALs",
                table: "RFMARITALs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RFMARITALs",
                table: "RFMARITALs");

            migrationBuilder.DropColumn(
                name: "JOB_CODE",
                table: "RFJOB");

            migrationBuilder.DropColumn(
                name: "ACTIVE",
                table: "RFMARITALs");

            migrationBuilder.DropColumn(
                name: "CORE_CODE",
                table: "RFMARITALs");

            migrationBuilder.DropColumn(
                name: "MR_CODE",
                table: "RFMARITALs");

            migrationBuilder.DropColumn(
                name: "MR_CODESIKP",
                table: "RFMARITALs");

            migrationBuilder.DropColumn(
                name: "MR_DESC",
                table: "RFMARITALs");

            migrationBuilder.RenameTable(
                name: "RFMARITALs",
                newName: "RFMARITAL");

            migrationBuilder.RenameColumn(
                name: "WITHSPOUSE",
                table: "RFMARITAL",
                newName: "MaritalStatusId");

            migrationBuilder.RenameColumn(
                name: "MR_DESCSIKP",
                table: "RFMARITAL",
                newName: "MaritalStatusName");

            migrationBuilder.AlterColumn<int>(
                name: "PRODUCTID",
                table: "RFJOB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CORE_CODE",
                table: "RFJOB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RFMARITAL",
                table: "RFMARITAL",
                column: "Id");
        }
    }
}
