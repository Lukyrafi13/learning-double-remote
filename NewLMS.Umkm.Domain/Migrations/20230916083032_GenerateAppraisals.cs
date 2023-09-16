using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class GenerateAppraisals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneratedFileGroups",
                columns: table => new
                {
                    GeneratedFileGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedFileGroupCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    GeneratedFileGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GeneratedFileGroups", x => x.GeneratedFileGroupGuid);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedFiles",
                columns: table => new
                {
                    GeneratedFileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneratedFileGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GeneratedFiles", x => x.GeneratedFileGuid);
                    table.ForeignKey(
                        name: "FK_GeneratedFiles_GeneratedFileGroups_GeneratedFileGroupGuid",
                        column: x => x.GeneratedFileGroupGuid,
                        principalTable: "GeneratedFileGroups",
                        principalColumn: "GeneratedFileGroupGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedFiles_LoanApplications_LoanApplicationGuid",
                        column: x => x.LoanApplicationGuid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedFiles_GeneratedFileGroupGuid",
                table: "GeneratedFiles",
                column: "GeneratedFileGroupGuid");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedFiles_LoanApplicationGuid",
                table: "GeneratedFiles",
                column: "LoanApplicationGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratedFiles");

            migrationBuilder.DropTable(
                name: "GeneratedFileGroups");
        }
    }
}
