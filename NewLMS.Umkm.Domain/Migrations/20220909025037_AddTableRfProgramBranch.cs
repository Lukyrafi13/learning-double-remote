using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfProgramBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreCode",
                table: "RfPrograms");

            migrationBuilder.CreateTable(
                name: "RfProgramBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(4)", nullable: true),
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
                    table.PrimaryKey("PK_RfProgramBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfProgramBranches_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_RfProgramBranches_RfPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "RfPrograms",
                        principalColumn: "ProgramId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfProgramBranches_BranchId",
                table: "RfProgramBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RfProgramBranches_ProgramId",
                table: "RfProgramBranches",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfProgramBranches");

            migrationBuilder.AddColumn<string>(
                name: "CoreCode",
                table: "RfPrograms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
