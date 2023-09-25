using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addRfMappingDocumentPrescreening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfMappingDocumentPrescreenings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OwnerCategoryId = table.Column<int>(type: "int", nullable: true),
                    DocumentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RfMappingDocumentPrescreenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfMappingDocumentPrescreenings_RfDocuments_DocumentCode",
                        column: x => x.DocumentCode,
                        principalTable: "RfDocuments",
                        principalColumn: "DocumentCode");
                    table.ForeignKey(
                        name: "FK_RfMappingDocumentPrescreenings_RfParameterDetails_OwnerCategoryId",
                        column: x => x.OwnerCategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_RfMappingDocumentPrescreenings_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingDocumentPrescreenings_DocumentCode",
                table: "RfMappingDocumentPrescreenings",
                column: "DocumentCode");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingDocumentPrescreenings_OwnerCategoryId",
                table: "RfMappingDocumentPrescreenings",
                column: "OwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RfMappingDocumentPrescreenings_ProductId",
                table: "RfMappingDocumentPrescreenings",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfMappingDocumentPrescreenings");
        }
    }
}
