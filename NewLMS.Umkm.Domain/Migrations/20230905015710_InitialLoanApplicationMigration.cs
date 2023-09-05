using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Umkm.Domain.Migrations
{
    public partial class InitialLoanApplicationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DebtorCompanyLegals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentDeedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDeedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatestDeedChange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIUPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIUPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TDPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TDPDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SKNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SKDPNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKDPDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_DebtorCompanyLegals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtorEmergencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorEmergencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtorEmergencies_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    ResidenceStatusId = table.Column<int>(type: "int", nullable: true),
                    ResidenceLiveTime = table.Column<int>(type: "int", nullable: true),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MarriageCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriageCertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarriageCertificateIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfHomestaParameterDetailId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Debtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debtors_RfEducations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfGenders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfJobs_JobCode",
                        column: x => x.JobCode,
                        principalTable: "RfJobs",
                        principalColumn: "JobCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfMaritals_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_Debtors_RfParameterDetails_ResidenceStatusId",
                        column: x => x.ResidenceStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Debtors_RfParameterDetails_RfHomestaParameterDetailId",
                        column: x => x.RfHomestaParameterDetailId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_Debtors_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DebtorCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorEmergencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        name: "FK_DebtorCompanies_DebtorEmergencies_DebtorEmergencyId",
                        column: x => x.DebtorEmergencyId,
                        principalTable: "DebtorEmergencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DebtorCompanies_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
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
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtorCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DebtorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DebtorEmergencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerCategoryId = table.Column<int>(type: "int", nullable: false),
                    DecisionMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingOfficeCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    RfBranchCode = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    RfProductProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfSectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfSubProductSubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_LoanApplications_DebtorCompanies_DebtorCompanyId",
                        column: x => x.DebtorCompanyId,
                        principalTable: "DebtorCompanies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfBranches_BookingOfficeCode",
                        column: x => x.BookingOfficeCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfBranches_RfBranchCode",
                        column: x => x.RfBranchCode,
                        principalTable: "RfBranches",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfParameterDetails_OwnerCategoryId",
                        column: x => x.OwnerCategoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfProducts_RfProductProductId",
                        column: x => x.RfProductProductId,
                        principalTable: "RfProducts",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfSectorLBU3_RfSectorLBU3Code",
                        column: x => x.RfSectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_RfSubProducts_RfSubProductSubProductId",
                        column: x => x.RfSubProductSubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_DecisionMakerId",
                        column: x => x.DecisionMakerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCollaterals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollateralBCId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentPublisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplicationCollaterals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollaterals_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCreditScorings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoResidentialReputationId = table.Column<int>(type: "int", nullable: false),
                    ScoBankRelationId = table.Column<int>(type: "int", nullable: false),
                    ScoBJBCreditHistoryId = table.Column<int>(type: "int", nullable: false),
                    ScoTransacMethodId = table.Column<int>(type: "int", nullable: false),
                    ScoAverageAccBalanceId = table.Column<int>(type: "int", nullable: false),
                    ScoNeedLevelId = table.Column<int>(type: "int", nullable: false),
                    ScoFinanceManagerId = table.Column<int>(type: "int", nullable: false),
                    ScoBusinesLocationId = table.Column<int>(type: "int", nullable: false),
                    ScoOtherPartyDebtId = table.Column<int>(type: "int", nullable: false),
                    ScoCollateralId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplicationCreditScorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_LoanApplications_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoAverageAccBalanceId",
                        column: x => x.ScoAverageAccBalanceId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBankRelationId",
                        column: x => x.ScoBankRelationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBJBCreditHistoryId",
                        column: x => x.ScoBJBCreditHistoryId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoBusinesLocationId",
                        column: x => x.ScoBusinesLocationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoCollateralId",
                        column: x => x.ScoCollateralId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoFinanceManagerId",
                        column: x => x.ScoFinanceManagerId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoNeedLevelId",
                        column: x => x.ScoNeedLevelId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoOtherPartyDebtId",
                        column: x => x.ScoOtherPartyDebtId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoResidentialReputationId",
                        column: x => x.ScoResidentialReputationId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCreditScorings_RfParameterDetails_ScoTransacMethodId",
                        column: x => x.ScoTransacMethodId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationTypeId = table.Column<int>(type: "int", nullable: false),
                    LoanPurposeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmittedPlafond = table.Column<long>(type: "bigint", nullable: false),
                    SubProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoanTerm = table.Column<int>(type: "int", nullable: false),
                    FacilityPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfCreditId = table.Column<int>(type: "int", nullable: false),
                    PrincipalInstallment = table.Column<long>(type: "bigint", nullable: false),
                    InterestInstallment = table.Column<long>(type: "bigint", nullable: false),
                    SectorLBU3Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfLoanPurposes_LoanPurposeId",
                        column: x => x.LoanPurposeId,
                        principalTable: "RfLoanPurposes",
                        principalColumn: "LoanPurposeCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfParameterDetails_ApplicationTypeId",
                        column: x => x.ApplicationTypeId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfParameterDetails_NatureOfCreditId",
                        column: x => x.NatureOfCreditId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfSectorLBU3_SectorLBU3Code",
                        column: x => x.SectorLBU3Code,
                        principalTable: "RfSectorLBU3",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_LoanApplicationFacilities_RfSubProducts_SubProductId",
                        column: x => x.SubProductId,
                        principalTable: "RfSubProducts",
                        principalColumn: "SubProductId");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationKeyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityDueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LifetimeIdentity = table.Column<bool>(type: "bit", nullable: false),
                    NPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoanApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationKeyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfEducations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfMaritals_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationKeyPersons_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_LoanApplicationStageLogs_RfStages_StageId",
                        column: x => x.StageId,
                        principalTable: "RfStages",
                        principalColumn: "StageId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationStageLogs_RfStages_TargetStage",
                        column: x => x.TargetStage,
                        principalTable: "RfStages",
                        principalColumn: "StageId");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationCollateralOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationCollateral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNPWP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerMaritalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OwnerIdentityExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerIdentityLifetime = table.Column<bool>(type: "bit", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityLifetime = table.Column<bool>(type: "bit", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCodeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: true),
                    ResidenceStatusId = table.Column<int>(type: "int", nullable: true),
                    ResidenceLiveTime = table.Column<int>(type: "int", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MarriageCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarriageCertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarriageCertificateIssuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmergencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerEmegencyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfEducationEducationCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RfHomestaParameterDetailId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationCollateralOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_LoanApplicationCollaterals_Id",
                        column: x => x.Id,
                        principalTable: "LoanApplicationCollaterals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfEducations_RfEducationEducationCode",
                        column: x => x.RfEducationEducationCode,
                        principalTable: "RfEducations",
                        principalColumn: "EducationCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfGenders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "RfGenders",
                        principalColumn: "GenderCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfJobs_JobCode",
                        column: x => x.JobCode,
                        principalTable: "RfJobs",
                        principalColumn: "JobCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfMaritals_OwnerMaritalId",
                        column: x => x.OwnerMaritalId,
                        principalTable: "RfMaritals",
                        principalColumn: "MaritalCode");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_ResidenceStatusId",
                        column: x => x.ResidenceStatusId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfParameterDetails_RfHomestaParameterDetailId",
                        column: x => x.RfHomestaParameterDetailId,
                        principalTable: "RfParameterDetails",
                        principalColumn: "ParameterDetailId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationCollateralOwners_RfZipCodes_ZipCodeId",
                        column: x => x.ZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_DebtorEmergencyId",
                table: "DebtorCompanies",
                column: "DebtorEmergencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCompanies_ZipCodeId",
                table: "DebtorCompanies",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_ZipCodeId",
                table: "DebtorEmergencies",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_EducationId",
                table: "Debtors",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_GenderId",
                table: "Debtors",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_JobCode",
                table: "Debtors",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_MaritalStatusId",
                table: "Debtors",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_ResidenceStatusId",
                table: "Debtors",
                column: "ResidenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfHomestaParameterDetailId",
                table: "Debtors",
                column: "RfHomestaParameterDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_ZipCodeId",
                table: "Debtors",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_GenderId",
                table: "LoanApplicationCollateralOwners",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_JobCode",
                table: "LoanApplicationCollateralOwners",
                column: "JobCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_OwnerMaritalId",
                table: "LoanApplicationCollateralOwners",
                column: "OwnerMaritalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_ResidenceStatusId",
                table: "LoanApplicationCollateralOwners",
                column: "ResidenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RfEducationEducationCode",
                table: "LoanApplicationCollateralOwners",
                column: "RfEducationEducationCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_RfHomestaParameterDetailId",
                table: "LoanApplicationCollateralOwners",
                column: "RfHomestaParameterDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollateralOwners_ZipCodeId",
                table: "LoanApplicationCollateralOwners",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_LoanApplicationId",
                table: "LoanApplicationCollaterals",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCollaterals_ZipCodeId",
                table: "LoanApplicationCollaterals",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoAverageAccBalanceId",
                table: "LoanApplicationCreditScorings",
                column: "ScoAverageAccBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBankRelationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBankRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBJBCreditHistoryId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBJBCreditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoBusinesLocationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoBusinesLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoCollateralId",
                table: "LoanApplicationCreditScorings",
                column: "ScoCollateralId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoFinanceManagerId",
                table: "LoanApplicationCreditScorings",
                column: "ScoFinanceManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoNeedLevelId",
                table: "LoanApplicationCreditScorings",
                column: "ScoNeedLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoOtherPartyDebtId",
                table: "LoanApplicationCreditScorings",
                column: "ScoOtherPartyDebtId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoResidentialReputationId",
                table: "LoanApplicationCreditScorings",
                column: "ScoResidentialReputationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationCreditScorings_ScoTransacMethodId",
                table: "LoanApplicationCreditScorings",
                column: "ScoTransacMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_ApplicationTypeId",
                table: "LoanApplicationFacilities",
                column: "ApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_LoanApplicationId",
                table: "LoanApplicationFacilities",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_LoanPurposeId",
                table: "LoanApplicationFacilities",
                column: "LoanPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_NatureOfCreditId",
                table: "LoanApplicationFacilities",
                column: "NatureOfCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_SectorLBU3Code",
                table: "LoanApplicationFacilities",
                column: "SectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationFacilities_SubProductId",
                table: "LoanApplicationFacilities",
                column: "SubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_EducationId",
                table: "LoanApplicationKeyPersons",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_LoanApplicationId",
                table: "LoanApplicationKeyPersons",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_MaritalStatusId",
                table: "LoanApplicationKeyPersons",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationKeyPersons_ZipCodeId",
                table: "LoanApplicationKeyPersons",
                column: "ZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BookingOfficeCode",
                table: "LoanApplications",
                column: "BookingOfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorCompanyId",
                table: "LoanApplications",
                column: "DebtorCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DebtorId",
                table: "LoanApplications",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DecisionMakerId",
                table: "LoanApplications",
                column: "DecisionMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerCategoryId",
                table: "LoanApplications",
                column: "OwnerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_OwnerId",
                table: "LoanApplications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfBranchCode",
                table: "LoanApplications",
                column: "RfBranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfProductProductId",
                table: "LoanApplications",
                column: "RfProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfSectorLBU3Code",
                table: "LoanApplications",
                column: "RfSectorLBU3Code");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_RfSubProductSubProductId",
                table: "LoanApplications",
                column: "RfSubProductSubProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_StageId",
                table: "LoanApplications",
                column: "StageId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtorCompanyLegals");

            migrationBuilder.DropTable(
                name: "LoanApplicationCollateralOwners");

            migrationBuilder.DropTable(
                name: "LoanApplicationCreditScorings");

            migrationBuilder.DropTable(
                name: "LoanApplicationFacilities");

            migrationBuilder.DropTable(
                name: "LoanApplicationKeyPersons");

            migrationBuilder.DropTable(
                name: "LoanApplicationStageLogs");

            migrationBuilder.DropTable(
                name: "LoanApplicationCollaterals");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "DebtorCompanies");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "DebtorEmergencies");
        }
    }
}
