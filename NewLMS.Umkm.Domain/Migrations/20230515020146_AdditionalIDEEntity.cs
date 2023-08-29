using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AdditionalIDEEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RFProducts_ProductId",
                table: "RFProducts",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "RFSifatKredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SKCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFSifatKredits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFSubProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    MandNPWP = table.Column<bool>(type: "bit", nullable: true),
                    LPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFSubProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFSubProducts_RFProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "RFProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RFTenorMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiklusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RFTenorMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFTenorMappings_RFProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "RFProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "RFTenors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TNCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TNDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Due = table.Column<int>(type: "int", nullable: true),
                    ManDocNo = table.Column<bool>(type: "bit", nullable: true),
                    ISTBO = table.Column<bool>(type: "bit", nullable: true),
                    Mandatory = table.Column<bool>(type: "bit", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RFTenors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFTenors_RFProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "RFProducts",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RFSubProducts_ProductId1",
                table: "RFSubProducts",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RFTenorMappings_ProductId1",
                table: "RFTenorMappings",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RFTenors_ProductId1",
                table: "RFTenors",
                column: "ProductId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFSifatKredits");

            migrationBuilder.DropTable(
                name: "RFSubProducts");

            migrationBuilder.DropTable(
                name: "RFTenorMappings");

            migrationBuilder.DropTable(
                name: "RFTenors");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RFProducts_ProductId",
                table: "RFProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "RFProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
