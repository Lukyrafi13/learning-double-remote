using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddParametersAndParametersGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ParameterGroups",
                columns: table => new
                {
                    ParameterGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParamaterGroupCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ParameterGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupSubMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_ParameterGroups", x => x.ParameterGroupGuid);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParameterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Parameters", x => x.ParameterGuid);
                    table.ForeignKey(
                        name: "FK_Parameters_ParameterGroups_ParameterGroupGuid",
                        column: x => x.ParameterGroupGuid,
                        principalTable: "ParameterGroups",
                        principalColumn: "ParameterGroupGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_ParameterGroupGuid",
                table: "Parameters",
                column: "ParameterGroupGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "ParameterGroups");
        }
    }
}
