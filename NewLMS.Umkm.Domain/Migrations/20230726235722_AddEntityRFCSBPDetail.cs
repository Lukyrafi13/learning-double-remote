using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddEntityRFCSBPDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFCSBPDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CSBPGrupID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailNama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFCSBPDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFCSBPHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CSBPGrupID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailNama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSBPDetailDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFCSBPHeaders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFCSBPDetails");

            migrationBuilder.DropTable(
                name: "RFCSBPHeaders");
        }
    }
}
