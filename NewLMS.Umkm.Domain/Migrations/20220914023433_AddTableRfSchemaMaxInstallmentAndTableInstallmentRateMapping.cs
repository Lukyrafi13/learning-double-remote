using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfSchemaMaxInstallmentAndTableInstallmentRateMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfInstallmentRateMappings",
                columns: table => new
                {
                    InstallmentRateId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TPLCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: false),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    TPLPrio = table.Column<int>(type: "int", nullable: false),
                    InstallmentRate = table.Column<float>(type: "real", nullable: false),
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
                    table.PrimaryKey("PK_RfInstallmentRateMappings", x => x.InstallmentRateId);
                });

            migrationBuilder.CreateTable(
                name: "RfSchemaMaxInstallments",
                columns: table => new
                {
                    SchemaMaxInstallment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SchemaMaxInstallmentDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RPC = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfSchemaMaxInstallments", x => x.SchemaMaxInstallment);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfInstallmentRateMappings");

            migrationBuilder.DropTable(
                name: "RfSchemaMaxInstallments");
        }
    }
}
