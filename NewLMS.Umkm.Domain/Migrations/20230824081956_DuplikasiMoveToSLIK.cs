using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class DuplikasiMoveToSLIK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescreeningDuplikasis");

            migrationBuilder.CreateTable(
                name: "SlikRequestDuplikasis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SearchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SearchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SearchDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResultType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AplikasiId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    SlikRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisDuplikasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SlikRequestDuplikasis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikRequestDuplikasis_RFJenisDuplikasi_RFJenisDuplikasiId",
                        column: x => x.RFJenisDuplikasiId,
                        principalTable: "RFJenisDuplikasi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikRequestDuplikasis_SlikRequests_SlikRequestId",
                        column: x => x.SlikRequestId,
                        principalTable: "SlikRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestDuplikasis_RFJenisDuplikasiId",
                table: "SlikRequestDuplikasis",
                column: "RFJenisDuplikasiId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestDuplikasis_SlikRequestId",
                table: "SlikRequestDuplikasis",
                column: "SlikRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlikRequestDuplikasis");

            migrationBuilder.CreateTable(
                name: "PrescreeningDuplikasis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisDuplikasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AplikasiId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Npwp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outstanding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SearchDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SearchId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SearchType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescreeningDuplikasis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescreeningDuplikasis_Prescreenings_PrescreeningId",
                        column: x => x.PrescreeningId,
                        principalTable: "Prescreenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescreeningDuplikasis_RFJenisDuplikasi_RFJenisDuplikasiId",
                        column: x => x.RFJenisDuplikasiId,
                        principalTable: "RFJenisDuplikasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDuplikasis_PrescreeningId",
                table: "PrescreeningDuplikasis",
                column: "PrescreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescreeningDuplikasis_RFJenisDuplikasiId",
                table: "PrescreeningDuplikasis",
                column: "RFJenisDuplikasiId");
        }
    }
}
