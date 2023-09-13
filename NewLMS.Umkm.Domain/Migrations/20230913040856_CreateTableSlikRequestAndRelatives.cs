using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class CreateTableSlikRequestAndRelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SLIKRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ReadAndUnderstand = table.Column<bool>(type: "bit", nullable: true),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminVerified = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalCreditCard = table.Column<double>(type: "float", nullable: false),
                    TotalLimitSlik = table.Column<double>(type: "float", nullable: false),
                    TotalOtherUses = table.Column<double>(type: "float", nullable: false),
                    TotalWorkingCapital = table.Column<double>(type: "float", nullable: false),
                    InquiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SLIKRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SLIKRequests_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SLIKRequests_RfBranches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "SLIKRequestDebtors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKDebtorType = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLIKDocumentUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KodeRefPengguna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TujuanPermintaan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLIKResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoboSlik = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SLIKRequestDebtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_FileUrls_SLIKDocumentUrlId",
                        column: x => x.SLIKDocumentUrlId,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_RfParameterDetails_SLIKDebtorType",
                        column: x => x.SLIKDebtorType,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SLIKRequestDebtors_SLIKRequests_SLIKRequestId",
                        column: x => x.SLIKRequestId,
                        principalTable: "SLIKRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKDebtorType",
                table: "SLIKRequestDebtors",
                column: "SLIKDebtorType");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKDocumentUrlId",
                table: "SLIKRequestDebtors",
                column: "SLIKDocumentUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequestDebtors_SLIKRequestId",
                table: "SLIKRequestDebtors",
                column: "SLIKRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SLIKRequests_BranchCode",
                table: "SLIKRequests",
                column: "BranchCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SLIKRequestDebtors");

            migrationBuilder.DropTable(
                name: "SLIKRequests");
        }
    }
}
