using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddRFProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefTenor = table.Column<int>(type: "int", nullable: false),
                    MaxTenor = table.Column<int>(type: "int", nullable: false),
                    DefIntType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefInterest = table.Column<double>(type: "float", nullable: false),
                    MinInterest = table.Column<double>(type: "float", nullable: false),
                    MaxInterest = table.Column<double>(type: "float", nullable: false),
                    DefProvPCTFee = table.Column<double>(type: "float", nullable: false),
                    DefAdminFee = table.Column<double>(type: "float", nullable: false),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    MaxLimit = table.Column<double>(type: "float", nullable: false),
                    LimitAppR = table.Column<double>(type: "float", nullable: false),
                    MinLimit = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_RfProducts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfProducts");
        }
    }
}
