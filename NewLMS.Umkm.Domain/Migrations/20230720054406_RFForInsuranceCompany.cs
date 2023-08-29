using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class RFForInsuranceCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFApprKomoditis");

            migrationBuilder.DropTable(
                name: "RFApprTanahLnkPertumbuhans");

            migrationBuilder.DropTable(
                name: "RFApprTanahLokasis");

            migrationBuilder.DropTable(
                name: "RFApprTingkatKesuburans");

            migrationBuilder.CreateTable(
                name: "RFBranchInsComps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFBranchInsComps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFInsCompanys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CompId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addr1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addr2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addr3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoRekening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RekFire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RekLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CompType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFInsCompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFInsRateTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TPLCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TPLDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFInsRateTemplates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFBranchInsComps");

            migrationBuilder.DropTable(
                name: "RFInsCompanys");

            migrationBuilder.DropTable(
                name: "RFInsRateTemplates");

            migrationBuilder.CreateTable(
                name: "RFApprKomoditis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    APPR_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPR_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFApprKomoditis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFApprTanahLnkPertumbuhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    APPR_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPR_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFApprTanahLnkPertumbuhans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFApprTanahLokasis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    APPR_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPR_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFApprTanahLokasis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFApprTingkatKesuburans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    APPR_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPR_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFApprTingkatKesuburans", x => x.Id);
                });
        }
    }
}
