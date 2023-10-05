using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class DuplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanApplicationDuplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SearchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SearchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SearchDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResultType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Npwp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outstanding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationDuplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationDuplications_LoanApplications_LoanApplicationGuid",
                        column: x => x.LoanApplicationGuid,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MSearches",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SearchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SearchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SearchDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResultType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
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
                    table.PrimaryKey("PK_MSearch", x => new { x.TypeId, x.SearchType, x.SearchId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDuplications_LoanApplicationGuid",
                table: "LoanApplicationDuplications",
                column: "LoanApplicationGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplicationDuplications");

            migrationBuilder.DropTable(
                name: "MSearch");
        }
    }
}
