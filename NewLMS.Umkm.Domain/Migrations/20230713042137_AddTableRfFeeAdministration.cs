using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddTableRfFeeAdministration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeeAdministrationType",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAdministrationFee",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinAdministrationFee",
                table: "SubmittedFacilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RateAdministrationFee",
                table: "SubmittedFacilities",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RfFeeAdministrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmissionType = table.Column<int>(type: "int", nullable: false),
                    Plafond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinFeeAdministration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxFeeAdministration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RateFeeAdministration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeeAdministrationType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfFeeAdministrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfFeeAdministrations_RfBranches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_RfFeeAdministrations_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfFeeAdministrations_BranchCode",
                table: "RfFeeAdministrations",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfFeeAdministrations_SubProductId",
                table: "RfFeeAdministrations",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfFeeAdministrations");

            migrationBuilder.DropColumn(
                name: "FeeAdministrationType",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "MaxAdministrationFee",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "MinAdministrationFee",
                table: "SubmittedFacilities");

            migrationBuilder.DropColumn(
                name: "RateAdministrationFee",
                table: "SubmittedFacilities");
        }
    }
}
