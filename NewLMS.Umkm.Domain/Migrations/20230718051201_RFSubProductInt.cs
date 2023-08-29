using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFSubProductInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFSubProductInts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinPlafon = table.Column<double>(type: "float", nullable: true),
                    MaxPlafon = table.Column<double>(type: "float", nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: true),
                    MaxTenor = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPLPrio = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IntType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<double>(type: "float", nullable: true),
                    ProvPCT = table.Column<double>(type: "float", nullable: true),
                    AdminFee = table.Column<double>(type: "float", nullable: true),
                    InterestEff = table.Column<double>(type: "float", nullable: true),
                    BaseRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParamSpread = table.Column<double>(type: "float", nullable: true),
                    BaseRateYear = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CoreProvCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFSubProductInts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFSubProductInts");
        }
    }
}
