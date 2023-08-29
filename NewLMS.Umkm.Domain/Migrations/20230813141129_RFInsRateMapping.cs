using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFInsRateMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFInsRateMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InsRateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: true),
                    MaxTenor = table.Column<int>(type: "int", nullable: true),
                    MinAge = table.Column<int>(type: "int", nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    TplPrio = table.Column<int>(type: "int", nullable: true),
                    InsRate = table.Column<double>(type: "float", nullable: true),
                    InsTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("113005de-06bc-44cb-b97f-a9c65c0c5465")),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFInsRateMappings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFInsRateMappings");
        }
    }
}
