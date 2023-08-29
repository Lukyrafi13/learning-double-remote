using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableDocumentSp3k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentSp3ks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DocumentSp3kUrl = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilesUrlFileUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DocumentSp3ks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentSp3ks_FileUrls_FilesUrlFileUrlId",
                        column: x => x.FilesUrlFileUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "FileUrlId");
                    table.ForeignKey(
                        name: "FK_DocumentSp3ks_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentSp3ks_RfProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_FilesUrlFileUrlId",
                table: "DocumentSp3ks",
                column: "FilesUrlFileUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_LoanApplicationId",
                table: "DocumentSp3ks",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentSp3ks_ProductId",
                table: "DocumentSp3ks",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentSp3ks");
        }
    }
}
