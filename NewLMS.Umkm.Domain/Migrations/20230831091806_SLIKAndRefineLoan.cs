using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class SLIKAndRefineLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecisionMakerParameterDetailId",
                table: "LoanApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "LoanApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RfBranchId",
                table: "LoanApplications",
                type: "nvarchar(4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RfDecisionMakerId",
                table: "LoanApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileUrl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_FileUrl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RFSANDIBI",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BI_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_GROUP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    KATEGORI_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LBU2_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFSANDIBI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfCreditType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditAgreement = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_RfCreditType", x => x.Id);
                });

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
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadAndUnderstand = table.Column<bool>(type: "bit", nullable: true),
                    ProcessStatus = table.Column<int>(type: "int", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminVerified = table.Column<byte>(type: "tinyint", nullable: false),
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
                        name: "FK_SlikRequests_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlikRequests_RfBranches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "SlikCreditHistorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SLIKNoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DebtorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RFSandiBIEconomySectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIBehaviourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFSandiBIApplicationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RFConditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlafondLimit = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    Outstanding = table.Column<int>(type: "int", nullable: false),
                    StuckDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RFSandiBICollectibilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SLIKStatus = table.Column<bool>(type: "bit", nullable: false),
                    RfCreditTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRobo = table.Column<bool>(type: "bit", nullable: false),
                    SlikObjectTypeId = table.Column<int>(type: "int", nullable: true),
                    BelumMemilikiSLIK = table.Column<bool>(type: "bit", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SlikCreditHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RFCondition_RFConditionId",
                        column: x => x.RFConditionId,
                        principalTable: "RFCondition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RFSANDIBI_RFSandiBIApplicationTypeId",
                        column: x => x.RFSandiBIApplicationTypeId,
                        principalTable: "RFSANDIBI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RFSANDIBI_RFSandiBIBehaviourId",
                        column: x => x.RFSandiBIBehaviourId,
                        principalTable: "RFSANDIBI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RFSANDIBI_RFSandiBICollectibilityId",
                        column: x => x.RFSandiBICollectibilityId,
                        principalTable: "RFSANDIBI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RFSANDIBI_RFSandiBIEconomySectorId",
                        column: x => x.RFSandiBIEconomySectorId,
                        principalTable: "RFSANDIBI",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_RfCreditType_RfCreditTypeId",
                        column: x => x.RfCreditTypeId,
                        principalTable: "RfCreditType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_SlikObjectTypes_SlikObjectTypeId",
                        column: x => x.SlikObjectTypeId,
                        principalTable: "SlikObjectTypes",
                        principalColumn: "SlikObjectTypeId");
                    table.ForeignKey(
                        name: "FK_SlikCreditHistorys_SlikRequests_SlikRequestId",
                        column: x => x.SlikRequestId,
                        principalTable: "SlikRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlikRequestObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlikObjectTypeId = table.Column<int>(type: "int", nullable: true),
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
                    Automatic = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_SlikRequestObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_FileUrl_SLIKDocumentUrl",
                        column: x => x.SLIKDocumentUrl,
                        principalTable: "FileUrl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_SlikObjectTypes_SlikObjectTypeId",
                        column: x => x.SlikObjectTypeId,
                        principalTable: "SlikObjectTypes",
                        principalColumn: "SlikObjectTypeId");
                    table.ForeignKey(
                        name: "FK_SlikRequestObjects_SlikRequests_SlikRequestId",
                        column: x => x.SlikRequestId,
                        principalTable: "SlikRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DecisionMakerParameterDetailId",
                table: "LoanApplications",
                column: "DecisionMakerParameterDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfBranchId",
                table: "LoanApplications",
                column: "RfBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RFConditionId",
                table: "SlikCreditHistorys",
                column: "RFConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RFSandiBIApplicationTypeId",
                table: "SlikCreditHistorys",
                column: "RFSandiBIApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RFSandiBIBehaviourId",
                table: "SlikCreditHistorys",
                column: "RFSandiBIBehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RFSandiBICollectibilityId",
                table: "SlikCreditHistorys",
                column: "RFSandiBICollectibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RFSandiBIEconomySectorId",
                table: "SlikCreditHistorys",
                column: "RFSandiBIEconomySectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_RfCreditTypeId",
                table: "SlikCreditHistorys",
                column: "RfCreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_SlikObjectTypeId",
                table: "SlikCreditHistorys",
                column: "SlikObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikCreditHistorys_SlikRequestId",
                table: "SlikCreditHistorys",
                column: "SlikRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SLIKDocumentUrl",
                table: "SlikRequestObjects",
                column: "SLIKDocumentUrl");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SlikObjectTypeId",
                table: "SlikRequestObjects",
                column: "SlikObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequestObjects_SlikRequestId",
                table: "SlikRequestObjects",
                column: "SlikRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_BranchCode",
                table: "SlikRequests",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_SlikRequests_LoanApplicationId",
                table: "SlikRequests",
                column: "LoanApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfBranches_RfBranchId",
                table: "LoanApplications",
                column: "RfBranchId",
                principalTable: "RfBranches",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_RfParameterDetails_DecisionMakerParameterDetailId",
                table: "LoanApplications",
                column: "DecisionMakerParameterDetailId",
                principalTable: "RfParameterDetails",
                principalColumn: "ParameterDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfBranches_RfBranchId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_RfParameterDetails_DecisionMakerParameterDetailId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropTable(
                name: "SlikCreditHistorys");

            migrationBuilder.DropTable(
                name: "SlikRequestObjects");

            migrationBuilder.DropTable(
                name: "RFCondition");

            migrationBuilder.DropTable(
                name: "RFSANDIBI");

            migrationBuilder.DropTable(
                name: "RfCreditType");

            migrationBuilder.DropTable(
                name: "FileUrl");

            migrationBuilder.DropTable(
                name: "SlikObjectTypes");

            migrationBuilder.DropTable(
                name: "SlikRequests");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DecisionMakerParameterDetailId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_RfBranchId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "DecisionMakerParameterDetailId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfBranchId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "RfDecisionMakerId",
                table: "LoanApplications");
        }
    }
}
