using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFPreDocMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocCode",
                table: "RFDocuments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RFDocuments_DocCode",
                table: "RFDocuments",
                column: "DocCode");

            migrationBuilder.CreateTable(
                name: "RFMappingPrescreeningDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_RFMappingPrescreeningDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFMappingPrescreeningDocuments_RFDocuments_DocCode",
                        column: x => x.DocCode,
                        principalTable: "RFDocuments",
                        principalColumn: "DocCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RFMappingPrescreeningDocuments_DocCode",
                table: "RFMappingPrescreeningDocuments",
                column: "DocCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFMappingPrescreeningDocuments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RFDocuments_DocCode",
                table: "RFDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "DocCode",
                table: "RFDocuments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
