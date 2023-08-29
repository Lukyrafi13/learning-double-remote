using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddSectorEntitites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RFSectorLBU3Code",
                table: "Prospects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RFSectorLBU1s",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFSectorLBU1s", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "RFSectorLBU2s",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LBCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFSectorLBU1Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFSectorLBU2s", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RFSectorLBU2s_RFSectorLBU1s_RFSectorLBU1Code",
                        column: x => x.RFSectorLBU1Code,
                        principalTable: "RFSectorLBU1s",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "RFSectorLBU3s",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false),
                    LBCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFSectorLBU2Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsShowing = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFSectorLBU3s", x => x.Code);
                    table.ForeignKey(
                        name: "FK_RFSectorLBU3s_RFSectorLBU2s_RFSectorLBU2Code",
                        column: x => x.RFSectorLBU2Code,
                        principalTable: "RFSectorLBU2s",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_RFSectorLBU3Code",
                table: "Prospects",
                column: "RFSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_RFSectorLBU2s_RFSectorLBU1Code",
                table: "RFSectorLBU2s",
                column: "RFSectorLBU1Code");

            migrationBuilder.CreateIndex(
                name: "IX_RFSectorLBU3s_RFSectorLBU2Code",
                table: "RFSectorLBU3s",
                column: "RFSectorLBU2Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_RFSectorLBU3s_RFSectorLBU3Code",
                table: "Prospects",
                column: "RFSectorLBU3Code",
                principalTable: "RFSectorLBU3s",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_RFSectorLBU3s_RFSectorLBU3Code",
                table: "Prospects");

            migrationBuilder.DropTable(
                name: "RFSectorLBU3s");

            migrationBuilder.DropTable(
                name: "RFSectorLBU2s");

            migrationBuilder.DropTable(
                name: "RFSectorLBU1s");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_RFSectorLBU3Code",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "RFSectorLBU3Code",
                table: "Prospects");
        }
    }
}
