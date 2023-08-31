using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class alterProspectWithParameterDetailadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RfAppTypeId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfCompanyGroupId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfCompanyStatusId",
                table: "Prospects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfAppTypeId",
                table: "Prospects",
                column: "RfAppTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyGroupId",
                table: "Prospects",
                column: "RfCompanyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RfCompanyStatusId",
                table: "Prospects",
                column: "RfCompanyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfAppTypeId",
                table: "Prospects",
                column: "RfAppTypeId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfCompanyGroupId",
                table: "Prospects",
                column: "RfCompanyGroupId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfCompanyStatusId",
                table: "Prospects",
                column: "RfCompanyStatusId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RfParameterDetails_RfCompanyStatusId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RfCompanyStatusId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfAppTypeId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfCompanyGroupId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RfCompanyStatusId",
                table: "Prospects");
        }
    }
}
