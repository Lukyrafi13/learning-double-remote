using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableRfProgramSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfProgramSubProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfProgramSubProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfProgramSubProduct_RfPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "RfPrograms",
                        principalColumn: "ProgramId");
                    table.ForeignKey(
                        name: "FK_RfProgramSubProduct_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfProgramSubProduct_ProgramId",
                table: "RfProgramSubProduct",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_RfProgramSubProduct_SubProductId",
                table: "RfProgramSubProduct",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfProgramSubProduct");
        }
    }
}
