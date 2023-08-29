using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class IDERFEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CORE_DESC",
                table: "RFSCOCARATRANSAKSI",
                newName: "CORE_CODE");

            migrationBuilder.CreateTable(
                name: "RFColLateralBCs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColcatCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<bool>(type: "bit", nullable: false),
                    Building = table.Column<bool>(type: "bit", nullable: false),
                    BeaGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFColLateralBCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFDocumentAgunans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFDocumentAgunans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Due = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<bool>(type: "bit", nullable: false),
                    ISTBO = table.Column<bool>(type: "bit", nullable: false),
                    Mandatory = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFMappingAgunan2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFMappingAgunan2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFRelationCols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Spouse = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RFRelationCols", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFColLateralBCs");

            migrationBuilder.DropTable(
                name: "RFDocumentAgunans");

            migrationBuilder.DropTable(
                name: "RFDocuments");

            migrationBuilder.DropTable(
                name: "RFMappingAgunan2s");

            migrationBuilder.DropTable(
                name: "RFRelationCols");

            migrationBuilder.RenameColumn(
                name: "CORE_CODE",
                table: "RFSCOCARATRANSAKSI",
                newName: "CORE_DESC");
        }
    }
}
