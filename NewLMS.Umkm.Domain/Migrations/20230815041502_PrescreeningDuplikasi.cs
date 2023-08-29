using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class PrescreeningDuplikasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFJenisDuplikasi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JenisCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JenisDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RFJenisDuplikasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrescreeningDuplikasis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RFJenisDuplikasiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    PrescreeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescreeningDuplikasis");

            migrationBuilder.DropTable(
                name: "RFJenisDuplikasi");
        }
    }
}
