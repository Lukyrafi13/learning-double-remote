using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfRateRateBranchAndRateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: false),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    RateNew = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateTopUp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpreadMusisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_RfRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfRates_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateTable(
                name: "RfRateBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpreadRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_RfRateBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfRateBranches_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_RfRateBranches_RfRates_RateId",
                        column: x => x.RateId,
                        principalTable: "RfRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfRateCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SpreadRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_RfRateCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfRateCompanies_RfCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "RfCompanies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_RfRateCompanies_RfRates_RateId",
                        column: x => x.RateId,
                        principalTable: "RfRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfRateBranches_BranchId",
                table: "RfRateBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RfRateBranches_RateId",
                table: "RfRateBranches",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_RfRateCompanies_CompanyId",
                table: "RfRateCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RfRateCompanies_RateId",
                table: "RfRateCompanies",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_RfRates_SubProductId",
                table: "RfRates",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfRateBranches");

            migrationBuilder.DropTable(
                name: "RfRateCompanies");

            migrationBuilder.DropTable(
                name: "RfRates");
        }
    }
}
