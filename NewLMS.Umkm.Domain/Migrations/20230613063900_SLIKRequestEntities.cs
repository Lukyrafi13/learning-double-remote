using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class SLIKRequestEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SlikObjectTypes",
                columns: table => new
                {
                    SlikObjectTypeId = table.Column<int>(type: "int", nullable: false),
                    SlikObjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SlikObjectTypes", x => x.SlikObjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SlikRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProcessStatus = table.Column<int>(type: "int", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminVerified = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalCreditCard = table.Column<int>(type: "int", nullable: false),
                    TotalLimitSlik = table.Column<int>(type: "int", nullable: false),
                    TotalOtheUsers = table.Column<int>(type: "int", nullable: false),
                    TotalWorkingCapital = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SlikRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikRequests_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlikRequests_RfBranches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "SlikRequestObjects",
                columns: table => new
                {
                    SlikRequestObjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikRequestGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikObjectTypeId = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLIKDocumentUrl = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SlikRequestObjects", x => x.SlikRequestObjectGuid);
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_FileUrls_SLIKDocumentUrl",
                        column: x => x.SLIKDocumentUrl,
                        principalTable: "FileUrls",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                        column: x => x.SlikObjectTypeId,
                        principalTable: "SlikObjectTypes",
                        principalColumn: "SlikObjectTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_SlikRequests_SlikRequestGuid",
                        column: x => x.SlikRequestGuid,
                        principalTable: "SlikRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SLIKDocumentUrl",
                table: "SlikRequestObjects",
                column: "SLIKDocumentUrl");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SlikObjectTypeId",
                table: "SlikRequestObjects",
                column: "SlikObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SlikRequestGuid",
                table: "SlikRequestObjects",
                column: "SlikRequestGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_AppId",
                table: "SlikRequests",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_BranchCode",
                table: "SlikRequests",
                column: "BranchCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlikRequestObjects");

            migrationBuilder.DropTable(
                name: "SlikObjectTypes");

            migrationBuilder.DropTable(
                name: "SlikRequests");
        }
    }
}
