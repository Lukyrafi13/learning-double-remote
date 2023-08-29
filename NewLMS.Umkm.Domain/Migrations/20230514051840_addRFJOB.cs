using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class addRFJOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFJOB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JOB_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCTID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTHER = table.Column<int>(type: "int", nullable: false),
                    JOB_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_CODESIKP = table.Column<int>(type: "int", nullable: false),
                    JOBSCR_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SENSITIVE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    JOB_DESCSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFJOB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFJOB");
        }
    }
}
