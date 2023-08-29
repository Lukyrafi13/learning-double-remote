using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class AddNewEntityRfBranches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dati = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kanwil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KanwilName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KanwilOri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KcName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kcp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriKanwilName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sandi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfBranches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfBranches");
        }
    }
}
