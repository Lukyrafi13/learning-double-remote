using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class AddNewTableParameterForRPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfBranchRpcs",
                columns: table => new
                {
                    BranchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rpc = table.Column<double>(type: "float", nullable: false),
                    UseKontigensi = table.Column<bool>(type: "bit", nullable: false),
                    RpcGaji = table.Column<double>(type: "float", nullable: false),
                    RpcTunjangan = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_RfBranchRpcs", x => new { x.BranchId, x.SubProductId });
                });

            migrationBuilder.CreateTable(
                name: "RfJobGrades",
                columns: table => new
                {
                    GradeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GradeDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MaxPlafon = table.Column<double>(type: "float", nullable: false),
                    Tenor = table.Column<int>(type: "int", nullable: false),
                    Rpc = table.Column<double>(type: "float", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    RetirementAge = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfJobGrades", x => x.GradeCode);
                });

            migrationBuilder.CreateTable(
                name: "RfJobPensiunTpls",
                columns: table => new
                {
                    TplCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    JobCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GolCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PangkatCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RetirementAge = table.Column<int>(type: "int", nullable: false),
                    MaxTermOfOffice = table.Column<int>(type: "int", nullable: false),
                    TplPrio = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfJobPensiunTpls", x => x.TplCode);
                });

            migrationBuilder.CreateTable(
                name: "RfPaymentMethods",
                columns: table => new
                {
                    PayCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PayDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MinTenor = table.Column<int>(type: "int", nullable: false),
                    maxTenor = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RfPaymentMethods", x => x.PayCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfBranchRpcs");

            migrationBuilder.DropTable(
                name: "RfJobGrades");

            migrationBuilder.DropTable(
                name: "RfJobPensiunTpls");

            migrationBuilder.DropTable(
                name: "RfPaymentMethods");
        }
    }
}
