using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AlterProspectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfParameterDetails_CompanyTypeId",
                table: "Prospects");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyTypeId",
                table: "Prospects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCompanyType",
                table: "Prospects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfCompanyTypes_CompanyTypeId",
                table: "Prospects",
                column: "CompanyTypeId",
                principalTable: "RfCompanyTypes",
                principalColumn: "CompanyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfCompanyTypes_CompanyTypeId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "OtherCompanyType",
                table: "Prospects");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyTypeId",
                table: "Prospects",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfParameterDetails_CompanyTypeId",
                table: "Prospects",
                column: "CompanyTypeId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }
    }
}
