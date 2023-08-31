using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.UMKM.Domain.Migrations
{
    public partial class LoanAppsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFMARITAL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MR_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MR_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CORE_CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    MR_CODESIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MR_DESCSIKP = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RFMARITAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfStage",
                columns: table => new
                {
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupStage = table.Column<int>(type: "int", nullable: false),
                    GroupStageDigiloan = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowInTracking = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfStage", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RfCompanyStatusId = table.Column<int>(type: "int", nullable: false),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfContactPersonZipCodeId = table.Column<int>(type: "int", nullable: false),
                    ContactPersonNeighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeedOfEstablishmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeedOfEstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestDeedOfChanges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SIUPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIUPDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDPExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TDPDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SKDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDPExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SKDPDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_CompanyEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_RfParameterDetails_RfCompanyStatusId",
                        column: x => x.RfCompanyStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_RfZipCodes_RfContactPersonZipCodeId",
                        column: x => x.RfContactPersonZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEntities_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtorCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
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
                    table.PrimaryKey("PK_DebtorCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorCompanies_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtorCouples",
                columns: table => new
                {
                    DebtorCoupleId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DebtorCoupleNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressSameWithDebtor = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DebtorCouples", x => x.DebtorCoupleId);
                    table.ForeignKey(
                        name: "FK_DebtorCouples_RFJOB_RfJobId",
                        column: x => x.RfJobId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebtorCouples_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtorEmergencies",
                columns: table => new
                {
                    DebtorEmergencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentityEmergency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: true),
                    DebtorId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
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
                    table.PrimaryKey("PK_DebtorEmergencies", x => x.DebtorEmergencyId);
                    table.ForeignKey(
                        name: "FK_DebtorEmergencies_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    LoanApplicationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StayDuration = table.Column<int>(type: "int", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    RfHomestaId = table.Column<int>(type: "int", nullable: true),
                    RfEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfJobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfMaritalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MarriageCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriageCertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarriageCertificateIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Debtors", x => x.NoIdentity);
                    table.ForeignKey(
                        name: "FK_Debtors_RFEDUCATION_RfEducationId",
                        column: x => x.RfEducationId,
                        principalTable: "RFEDUCATION",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debtors_RfGenders_RfGenderId",
                        column: x => x.RfGenderId,
                        principalTable: "RfGenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Debtors_RFJOB_RfJobId",
                        column: x => x.RfJobId,
                        principalTable: "RFJOB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debtors_RFMARITAL_RfMaritalId",
                        column: x => x.RfMaritalId,
                        principalTable: "RFMARITAL",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Debtors_RfParameterDetails_RfHomestaId",
                        column: x => x.RfHomestaId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Debtors_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RfOwnerCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompanyEntityGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_CompanyEntities_CompanyEntityGuid",
                        column: x => x.CompanyEntityGuid,
                        principalTable: "CompanyEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Debtors_NoIdentity",
                        column: x => x.NoIdentity,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfOwnerCategories_RfOwnerCategoryId",
                        column: x => x.RfOwnerCategoryId,
                        principalTable: "RfOwnerCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationStageLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DispatchedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetStage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Aging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackStaged = table.Column<bool>(type: "bit", nullable: true),
                    RFRejectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationStageLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStageLogs_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationStageLogs_RfStage_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStage",
                        principalColumn: "StageId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationStageLogs_RfStage_TargetStage",
                        column: x => x.TargetStage,
                        principalTable: "RfStage",
                        principalColumn: "StageId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_LoanApplicationGuid",
                table: "CompanyEntities",
                column: "LoanApplicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_RfCompanyStatusId",
                table: "CompanyEntities",
                column: "RfCompanyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_RfContactPersonZipCodeId",
                table: "CompanyEntities",
                column: "RfContactPersonZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEntities_RfZipCodeId",
                table: "CompanyEntities",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_DebtorId",
                table: "DebtorCompanies",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_RfZipCodeId",
                table: "DebtorCompanies",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCouples_RfJobId",
                table: "DebtorCouples",
                column: "RfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCouples_RfZipCodeId",
                table: "DebtorCouples",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_RfZipCodeId",
                table: "DebtorEmergencies",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_LoanApplicationGuid",
                table: "Debtors",
                column: "LoanApplicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfEducationId",
                table: "Debtors",
                column: "RfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfGenderId",
                table: "Debtors",
                column: "RfGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfHomestaId",
                table: "Debtors",
                column: "RfHomestaId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfJobId",
                table: "Debtors",
                column: "RfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfMaritalId",
                table: "Debtors",
                column: "RfMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfZipCodeId",
                table: "Debtors",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CompanyEntityGuid",
                table: "LoanApplications",
                column: "CompanyEntityGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_NoIdentity",
                table: "LoanApplications",
                column: "NoIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfOwnerCategoryId",
                table: "LoanApplications",
                column: "RfOwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStageLogs_LoanApplicationId",
                table: "LoanApplicationStageLogs",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStageLogs_StageId",
                table: "LoanApplicationStageLogs",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationStageLogs_TargetStage",
                table: "LoanApplicationStageLogs",
                column: "TargetStage");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyEntities_LoanApplications_LoanApplicationGuid",
                table: "CompanyEntities",
                column: "LoanApplicationGuid",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCompanies_Debtors_DebtorId",
                table: "DebtorCompanies",
                column: "DebtorId",
                principalTable: "Debtors",
                principalColumn: "NoIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorCouples_Debtors_DebtorCoupleId",
                table: "DebtorCouples",
                column: "DebtorCoupleId",
                principalTable: "Debtors",
                principalColumn: "NoIdentity",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebtorEmergencies_Debtors_DebtorId",
                table: "DebtorEmergencies",
                column: "DebtorId",
                principalTable: "Debtors",
                principalColumn: "NoIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_Debtors_LoanApplications_LoanApplicationGuid",
                table: "Debtors",
                column: "LoanApplicationGuid",
                principalTable: "LoanApplications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyEntities_LoanApplications_LoanApplicationGuid",
                table: "CompanyEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Debtors_LoanApplications_LoanApplicationGuid",
                table: "Debtors");

            migrationBuilder.DropTable(
                name: "DebtorCompanies");

            migrationBuilder.DropTable(
                name: "DebtorCouples");

            migrationBuilder.DropTable(
                name: "DebtorEmergencies");

            migrationBuilder.DropTable(
                name: "LoanApplicationStageLogs");

            migrationBuilder.DropTable(
                name: "RfStage");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "CompanyEntities");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "RFMARITAL");
        }
    }
}
