using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableSkkSP3k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkkSp3ks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountOfficerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stakeholders1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Stakeholders2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SkkSp3ks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkkSp3ks_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkkSp3ks_SCJabatans_Position1",
                        column: x => x.Position1,
                        principalTable: "SCJabatans",
                        principalColumn: "JabCode");
                    table.ForeignKey(
                        name: "FK_SkkSp3ks_SCJabatans_Position2",
                        column: x => x.Position2,
                        principalTable: "SCJabatans",
                        principalColumn: "JabCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkkSp3ks_LoanApplicationId",
                table: "SkkSp3ks",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SkkSp3ks_Position1",
                table: "SkkSp3ks",
                column: "Position1");

            migrationBuilder.CreateIndex(
                name: "IX_SkkSp3ks_Position2",
                table: "SkkSp3ks",
                column: "Position2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkkSp3ks");
        }
    }
}
