using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class addRfJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFJOB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JOB_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOBSCR_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SENSITIVE = table.Column<bool>(type: "bit", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    OTHER = table.Column<bool>(type: "bit", nullable: true),
                    PRODUCTID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB_CODESIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
