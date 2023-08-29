using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableParamSubProductAdministrationFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubProductAdministrations",
                columns: table => new
                {
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RfBranchCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    RfSubProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LowLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpperLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProductAdministrations", x => new { x.RfBranchCode, x.RfSubProductId, x.IsDeleted });
                    table.ForeignKey(
                        name: "FK_SubProductAdministrations_RfBranches_RfBranchCode",
                        column: x => x.RfBranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProductAdministrations_RfSubProducts_RfSubProductId",
                        column: x => x.RfSubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubProductAdministrations_RfSubProductId",
                table: "SubProductAdministrations",
                column: "RfSubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProductAdministrations");
        }
    }
}
