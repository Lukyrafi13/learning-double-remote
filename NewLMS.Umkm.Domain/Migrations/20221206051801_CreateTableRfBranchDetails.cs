using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class CreateTableRfBranchDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfBranchDetails",
                columns: table => new
                {
                    BranchId = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    RW = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Kelurahan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Kecamatan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Kota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Provinsi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dati_II = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1Area = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Phone1Num = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone1Ext = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Phone2Area = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Phone2Num = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2Ext = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FaxArea = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FaxNum = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FaxExt = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchInitial = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_RfBranchDetails", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_RfBranchDetails_RfBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "RfBranches",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfBranchDetails");
        }
    }
}
