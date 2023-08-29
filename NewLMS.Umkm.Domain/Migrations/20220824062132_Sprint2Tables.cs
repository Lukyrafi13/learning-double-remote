using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLMS.Domain.Migrations
{
    public partial class Sprint2Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    NoIdentity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NoBankAccount = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPWP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MartialStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnderwriterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDependents = table.Column<int>(type: "int", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProspectId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankRelation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplications", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "ProspectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfPrograms",
                columns: table => new
                {
                    ProgramId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepaymentDisc = table.Column<bool>(type: "bit", nullable: false),
                    DefProvPctFee = table.Column<float>(type: "real", nullable: false),
                    MaxProvPctFee = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_RfPrograms", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "DebtorCollaterals",
                columns: table => new
                {
                    DebtorCollateralId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 16, nullable: false),
                    NoOwnershipProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollateralValue = table.Column<int>(type: "int", nullable: false),
                    CollateralOnBehalfOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationWithDebtor = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_DebtorCollaterals", x => x.DebtorCollateralId);
                    table.ForeignKey(
                        name: "FK_DebtorCollaterals_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity");
                });

            migrationBuilder.CreateTable(
                name: "DebtorCouples",
                columns: table => new
                {
                    DebtorCoupleId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DebtorCoupleNoIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    NoMarriageCertificate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DateMarriageCertificate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
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
                        name: "FK_DebtorCouples_Debtors_DebtorCoupleId",
                        column: x => x.DebtorCoupleId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtorEmergencies",
                columns: table => new
                {
                    DebtorEmergencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtorRelation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_DebtorEmergencies_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity");
                });

            migrationBuilder.CreateTable(
                name: "DebtorFinance",
                columns: table => new
                {
                    DebtorFinanceId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NoCandidateDecree = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NoEmployeeDecree = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NoLastRankDecree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoPeriodicallyDecree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoTaspenDecree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOtherDecree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoEducationDecree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StipulationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RetirementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayrollInBjb = table.Column<bool>(type: "bit", nullable: false),
                    BasicSallary = table.Column<int>(type: "int", nullable: false),
                    NetSalary = table.Column<int>(type: "int", nullable: false),
                    PerformanceAllowance = table.Column<int>(type: "int", nullable: false),
                    CertificationAllowance = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhoods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RfZipCodeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DebtorFinance", x => x.DebtorFinanceId);
                    table.ForeignKey(
                        name: "FK_DebtorFinance_Debtors_DebtorFinanceId",
                        column: x => x.DebtorFinanceId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebtorFinance_RfCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "RfCompanies",
                        principalColumn: "CompId");
                    table.ForeignKey(
                        name: "FK_DebtorFinance_RfZipCodes_RfZipCodeId",
                        column: x => x.RfZipCodeId,
                        principalTable: "RfZipCodes",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedFacilities",
                columns: table => new
                {
                    FacilityId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedFacilityTotal = table.Column<int>(type: "int", nullable: false),
                    UnderlyingRemainder = table.Column<int>(type: "int", nullable: false),
                    FloatingRate = table.Column<float>(type: "real", nullable: false),
                    AdministrationFee = table.Column<float>(type: "real", nullable: false),
                    OneMonthFloatingRate = table.Column<float>(type: "real", nullable: false),
                    CreditInterest = table.Column<float>(type: "real", nullable: false),
                    ProvisionFee = table.Column<int>(type: "int", nullable: false),
                    InsuranceFee = table.Column<int>(type: "int", nullable: false),
                    InstallmentFee = table.Column<int>(type: "int", nullable: false),
                    NotaryFee = table.Column<int>(type: "int", nullable: false),
                    ReceivedFacilityTotal = table.Column<int>(type: "int", nullable: false),
                    Plafond = table.Column<int>(type: "int", nullable: false),
                    Outstanding = table.Column<int>(type: "int", nullable: false),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaturityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ReceivedFacilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_ReceivedFacilities_Debtors_DebtorId",
                        column: x => x.DebtorId,
                        principalTable: "Debtors",
                        principalColumn: "NoIdentity");
                    table.ForeignKey(
                        name: "FK_ReceivedFacilities_LoanApplications_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedFacilities",
                columns: table => new
                {
                    SubmittedFacilityId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubmissionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedPlafond = table.Column<int>(type: "int", nullable: false),
                    InterestType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanTerm = table.Column<int>(type: "int", nullable: false),
                    MaximumPlafond = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    InterestSpread = table.Column<float>(type: "real", nullable: false),
                    InterestTotal = table.Column<float>(type: "real", nullable: false),
                    MonthlyInstallment = table.Column<int>(type: "int", nullable: false),
                    PaymentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPC = table.Column<float>(type: "real", nullable: false),
                    BindingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SubmittedFacilities", x => x.SubmittedFacilityId);
                    table.ForeignKey(
                        name: "FK_SubmittedFacilities_LoanApplications_SubmittedFacilityId",
                        column: x => x.SubmittedFacilityId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RfSubPrograms",
                columns: table => new
                {
                    SubProgramId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramId = table.Column<string>(type: "nvarchar(15)", nullable: true),
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
                    table.PrimaryKey("PK_RfSubPrograms", x => x.SubProgramId);
                    table.ForeignKey(
                        name: "FK_RfSubPrograms_RfPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "RfPrograms",
                        principalColumn: "ProgramId");
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationSubProgram",
                columns: table => new
                {
                    LoanApplicationSubProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SubProgramId = table.Column<string>(type: "nvarchar(15)", nullable: true),
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
                    table.PrimaryKey("PK_LoanApplicationSubProgram", x => x.LoanApplicationSubProgramId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationSubProgram_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId");
                    table.ForeignKey(
                        name: "FK_LoanApplicationSubProgram_RfSubPrograms_SubProgramId",
                        column: x => x.SubProgramId,
                        principalTable: "RfSubPrograms",
                        principalColumn: "SubProgramId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebtorCollaterals_DebtorId",
                table: "DebtorCollaterals",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorEmergencies_DebtorId",
                table: "DebtorEmergencies",
                column: "DebtorId",
                unique: true,
                filter: "[DebtorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorFinance_CompanyId",
                table: "DebtorFinance",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DebtorFinance_RfZipCodeId",
                table: "DebtorFinance",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debtors_RfZipCodeId",
                table: "Debtors",
                column: "RfZipCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ProspectId",
                table: "LoanApplications",
                column: "ProspectId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSubProgram_LoanApplicationId",
                table: "LoanApplicationSubProgram",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationSubProgram_SubProgramId",
                table: "LoanApplicationSubProgram",
                column: "SubProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedFacilities_DebtorId",
                table: "ReceivedFacilities",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubPrograms_ProgramId",
                table: "RfSubPrograms",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtorCollaterals");

            migrationBuilder.DropTable(
                name: "DebtorCouples");

            migrationBuilder.DropTable(
                name: "DebtorEmergencies");

            migrationBuilder.DropTable(
                name: "DebtorFinance");

            migrationBuilder.DropTable(
                name: "LoanApplicationSubProgram");

            migrationBuilder.DropTable(
                name: "ReceivedFacilities");

            migrationBuilder.DropTable(
                name: "SubmittedFacilities");

            migrationBuilder.DropTable(
                name: "RfSubPrograms");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "RfPrograms");

        }
    }
}
