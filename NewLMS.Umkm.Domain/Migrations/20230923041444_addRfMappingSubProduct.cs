using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addRfMappingSubProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfMappingSubProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    CreditPurposeId = table.Column<int>(type: "int", nullable: true),
                    MinPlafond = table.Column<double>(type: "float", nullable: true),
                    MaxPlafond = table.Column<double>(type: "float", nullable: true),
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
                    table.PrimaryKey("PK_RfMappingSubProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfMappingSubProducts_RfParameterDetails_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_RfMappingSubProducts_RfParameterDetails_CreditPurposeId",
                        column: x => x.CreditPurposeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_RfMappingSubProducts_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingSubProducts_ApplicationTypeId",
                table: "RfMappingSubProducts",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingSubProducts_CreditPurposeId",
                table: "RfMappingSubProducts",
                column: "CreditPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingSubProducts_SubProductId",
                table: "RfMappingSubProducts",
                column: "SubProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfMappingSubProducts");
        }
    }
}
