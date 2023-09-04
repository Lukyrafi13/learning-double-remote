using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addRfCompanyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfCompanyTypes",
                columns: table => new
                {
                    CompanyTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyTypeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfCompanyTypes", x => x.CompanyTypeId);
                    table.ForeignKey(
                        name: "FK_RfCompanyTypes_RfParameterDetails_CompanyGroupId",
                        column: x => x.CompanyGroupId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfCompanyTypes_CompanyGroupId",
                table: "RfCompanyTypes",
                column: "CompanyGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfCompanyTypes");
        }
    }
}
