using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfSandiBIAndRfSandiBIGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfSandiBIGroups",
                columns: table => new
                {
                    RfSandiBIGroupId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSandiBIGroups", x => x.RfSandiBIGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RfSandBIs",
                columns: table => new
                {
                    RfSandiBIId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    RfSandiBIGroupId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    BIType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    BICode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    BIDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RfSandBIs", x => x.RfSandiBIId);
                    table.ForeignKey(
                        name: "FK_RfSandBIs_RfSandiBIGroups_RfSandiBIGroupId",
                        column: x => x.RfSandiBIGroupId,
                        principalTable: "RfSandiBIGroups",
                        principalColumn: "RfSandiBIGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfSandBIs_RfSandiBIGroupId",
                table: "RfSandBIs",
                column: "RfSandiBIGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "RfSandBIs");

            migrationBuilder.DropTable(
                name: "RfSandiBIGroups");
        }
    }
}
