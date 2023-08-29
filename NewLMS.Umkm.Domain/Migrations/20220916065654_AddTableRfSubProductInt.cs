using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class AddTableRfSubProductInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfSubProductInterests",
                columns: table => new
                {
                    TplCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SubProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GolCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PngktCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MinAge = table.Column<int>(type: "int", nullable: true),
                    MaxAge = table.Column<int>(type: "int", nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: true),
                    MaxTenor = table.Column<int>(type: "int", nullable: true),
                    TplPrio = table.Column<int>(type: "int", nullable: true),
                    InterestNew = table.Column<double>(type: "float", nullable: true),
                    IntersetTopUp = table.Column<double>(type: "float", nullable: true),
                    InterestRepeat = table.Column<double>(type: "float", nullable: true),
                    MusisiNew = table.Column<double>(type: "float", nullable: true),
                    MusisiTopUp = table.Column<double>(type: "float", nullable: true),
                    MusisiRepeat = table.Column<double>(type: "float", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndRate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParamSpread = table.Column<double>(type: "float", nullable: true),
                    BaseRateYear = table.Column<int>(type: "int", nullable: true),
                    InterestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestPromoType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BatchIdSeq = table.Column<int>(type: "int", nullable: true),
                    GracePeriodCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfSubProductInterests", x => x.TplCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfSubProductInterests");
        }
    }
}
