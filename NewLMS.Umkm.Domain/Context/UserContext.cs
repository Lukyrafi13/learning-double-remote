using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Dto.RfStages;

namespace NewLMS.Umkm.Domain.Context
{
    public class UserContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        #region Base Entities
        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public override DbSet<UserClaim> UserClaims { get; set; }
        public override DbSet<UserRole> UserRoles { get; set; }
        public override DbSet<UserLogin> UserLogins { get; set; }
        public override DbSet<RoleClaim> RoleClaims { get; set; }
        public override DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Data.Action> Actions { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageAction> PageActions { get; set; }
        public DbSet<NLog> NLog { get; set; }
        public DbSet<LoginAudit> LoginAudits { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<UserAllowedIP> UserAllowedIPs { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailSMTPSetting> EmailSMTPSettings { get; set; }
        public virtual DbSet<UserDevice> UserDevices { get; set; }
        #endregion


        public virtual DbSet<ThridParty> ThridParties { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<ParameterGroups> ParameterGroups { get; set; }
        public DbSet<GeneratedFiles> GeneratedFiles { get; set; }
        public DbSet<GeneratedFileGroups> GeneratedFileGroups { get; set; }

        #region Transactions
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<LoanApplicationCollateral> LoanApplicationCollaterals { get; set; }
        public DbSet<LoanApplicationCollateralOwner> LoanApplicationCollateralOwners { get; set; }
        public DbSet<LoanApplicationCreditScoring> LoanApplicationCreditScorings { get; set; }
        public DbSet<LoanApplicationKeyPerson> LoanApplicationKeyPersons { get; set; }
        public DbSet<LoanApplicationFacility> LoanApplicationFacilities { get; set; }
        public DbSet<LoanApplicationStage> LoanApplicationStages { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<DebtorCouple> DebtorCouples { get; set; }
        public DbSet<DebtorCompany> DebtorCompanies { get; set; }
        public DbSet<DebtorEmergency> DebtorEmergencies { get; set; }
        public DbSet<DebtorCompanyLegal> DebtorCompanyLegals { get; set; }
        public DbSet<SLIKRequest> SLIKRequests { get; set; }
        public DbSet<SLIKRequestDebtor> SLIKRequestDebtors { get; set; }
        public DbSet<FileUrl> FileUrls { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentFileUrl> DocumentFileUrls { get; set; }
        public DbSet<LoanApplicationRAC> LoanApplicationRACs { get; set; }
        public DbSet<SIKP> SIKPs { get; set; }
        public DbSet<SIKPRequest> SIKPRequests { get; set; }
        public DbSet<SIKPResponse> SIKPResponses { get; set; }
        public DbSet<LoanApplicationAppraisal> LoanApplicationAppraisals { get; set; }
        public DbSet<ApprBuildingTemplates> ApprBuildingTemplates { get; set; }
        public DbSet<ApprBuildingFloors> ApprBuildingFloors { get; set; }
        public DbSet<ApprBuildingFloorDetails> ApprBuildingFloorDetails { get; set; }
        public DbSet<ApprLandTemplates> ApprLandTemplates { get; set; }
        public DbSet<ApprWorkPaperLandBuildingSummaries> ApprWorkPaperLandBuildingSummaries { get; set; }
        public DbSet<ApprWorkPaperLandBuildings> ApprWorkPaperLandBuildings { get; set; }
        public DbSet<ApprLiquidation> ApprLiquidations { get; set; }
        public DbSet<MLiquidationItem> MLiquidationItems { get; set; }
        public DbSet<ApprWorkPaperMachineMarketSummaries> ApprWorkPaperMachineMarketSummaries { get; set; }
        public DbSet<ApprMachineTemplate> ApprMachineTemplates { get; set; }
        public DbSet<ApprWorkPaperMachineCost> ApprWorkPaperMachineCost { get; set; }
        public DbSet<ApprWorkPaperMachineMarkets> ApprWorkPaperMachineMarkets { get; set; }
        public DbSet<ApprWorkPaperShopApartmentSummaries> ApprWorkPaperShopApartmentSummaries { get; set; }
        public DbSet<ApprWorkPaperShopApartments> ApprWorkPaperShopApartments { get; set; }
        public DbSet<ApprWorkPaperVehicleSummaries> ApprWorkPaperVehicleSummaries { get; set; }
        public DbSet<ApprWorkPaperVehicles> ApprWorkPaperVehicles { get; set; }
        public DbSet<ApprVehicleTemplate> ApprVehicleTemplate { get; set; }
        public DbSet<ApprChecklistReview> ApprChecklistReviews { get; set; }
        public DbSet<ApprReceivableVerification> ApprReceivableVerifications { get; set; }
        public DbSet<ApprVehicleNote> ApprVehicleNotes { get; set; }
        public DbSet<LoanApplicationFieldSurvey> LoanApplicationFieldSurveys { get; set; }
        public DbSet<LoanApplicationFieldSurveyDetail> LoanApplicationFieldSurveyDetails { get; set; }
        public DbSet<LoanApplicationVerificationBusiness> LoanApplicationVerificationBusinesses { get; set; }
        public DbSet<LoanApplicationVerificationCycle> LoanApplicationVerificationCycles { get; set; }
        public DbSet<LoanApplicationVerificationCycleDetail> LoanApplicationVerificationCycleDetails { get; set; }

        #endregion

        #region References
        public virtual DbSet<RfZipCode> RfZipCodes { get; set; }
        public DbSet<RfCompanyType> RfCompanyTypes { get; set; }
        public DbSet<RfStage> RfStages { get; set; }
        public DbSet<RfApplicationType> RfApplicationTypes { get; set; }
        public DbSet<RfBusinessFieldKUR> RfBusinessFieldKURs { get; set; }
        public DbSet<RfBusinessLocation> RfBusinessLocations { get; set; }
        public DbSet<RfBusinessOwnership> RfBusinessOwnerships { get; set; }
        public DbSet<RfBusinessPlaceLocation> RfBusinessPlaceLocations { get; set; }
        public DbSet<RfBusinessPlaceOwnership> RfBusinessPlaceOwnerships { get; set; }
        public DbSet<RfBusinessPlaceType> RfBusinessPlaceTypes { get; set; }
        public DbSet<RfBusinessType> RfBusinessTypes { get; set; }
        public DbSet<RfCollateralBC> RfCollateralBCs { get; set; }
        public DbSet<RfCreditNature> RfCreditNatures { get; set; }
        public DbSet<RfDecisionLeterType> RfDecisionLeterTypes { get; set; }
        public DbSet<RfDecisionLetter> RfDecisionLetters { get; set; }
        public DbSet<RfDocument> RfDocuments { get; set; }
        public DbSet<RfDocumentCollateral> RfDocumentCollaterals { get; set; }
        public DbSet<RfEducation> RfEducations { get; set; }
        public DbSet<RfGender> RfGenders { get; set; }
        public DbSet<RfJob> RfJobs { get; set; }
        public DbSet<RfLinkAge> RfLinkAges { get; set; }
        public DbSet<RfLinkAgeType> RfLinkAgeTypes { get; set; }
        public DbSet<RfLoanPurpose> RfLoanPurposes { get; set; }
        public DbSet<RfMappingCollateral> RfMappingCollaterals { get; set; }
        public DbSet<RfMappingTenor> RfMappingTenors { get; set; }
        public DbSet<RfMarital> RfMaritals { get; set; }
        public DbSet<RfParameter> RfParameters { get; set; }
        public DbSet<RfParameterDetail> RfParameterDetails { get; set; }
        public DbSet<RfPlacementCountry> RfPlacementCountries { get; set; }
        public DbSet<RfProduct> RfProducts { get; set; }
        public DbSet<RfRelationCol> RfRelationCols { get; set; }
        public DbSet<RfScPosition> RfScPositions { get; set; }
        public DbSet<RfSubProduct> RfSubProducts { get; set; }
        public DbSet<RfTenor> RfTenors { get; set; }
        public DbSet<RfTransportationType> RfTransportationTypes { get; set; }
        public DbSet<RfVehClass> RfVehClasss { get; set; }
        public DbSet<RfVehCountry> RfVehCountries { get; set; }
        public DbSet<RfVehMaker> RfVehMakers { get; set; }
        public DbSet<RfVehModel> RfVehModels { get; set; }
        public DbSet<RfVehType> RfVehTypes { get; set; }
        public DbSet<RfBranch> RfBranches { get; set; }
        public DbSet<RfInstallmentType> RfInstallmentTypes { get; set; }
        public DbSet<RfCondition> RfConditions { get; set; }
        public DbSet<RfCreditType> RfCreditTypes { get; set; }
        public DbSet<RfSandiBI> RfSandiBIs { get; set; }
        public DbSet<RfSandiBIGroup> RfSandiBIGroups { get; set; }
        public DbSet<RfDecisionMaker> RfDecisionMakers { get; set; }
        public DbSet<RfAppraisalKJPPMaster> RfAppraisalKJPPMasters { get; set; }
        public DbSet<WilayahProvinces> WilayahProvinces { get; set; }
        public DbSet<WilayahRegencies> WilayahRegencies { get; set; }
        public DbSet<WilayahDistricts> WilayahDistricts { get; set; }
        public DbSet<WilayahVillages> WilayahVillages { get; set; }
        public DbSet<RfSkemaSIKP> RfSkemaSIKPs { get; set; }
        public DbSet<RfMappingSubProduct> RfMappingSubProducts { get; set; }
        public DbSet<SIKPHistory> SIKPHistories { get; set; }
        public DbSet<SIKPHistoryDetail> SIKPHistoryDetails { get; set; }
        public DbSet<RfMappingDocumentPrescreening> RfMappingDocumentPrescreenings { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MLiquidation>().HasKey(x => new { x.TypeId });
            builder.Entity<MLiquidationCondition>(b =>
            {
                b.HasKey(x => new { x.TypeId, x.ConditionId });
                b.HasOne(s => s.MLiquidation)
                .WithMany(c => c.MLiquidationConditions)
                .HasForeignKey(s => new { s.TypeId });
            });

            builder.Entity<MLiquidationItem>(b =>
            {
                b.HasKey(s => new { s.TypeId, s.ItemId });
                b.HasOne(s => s.MLiquidation)
                .WithMany(c => c.MLiquidationItems)
                .HasForeignKey(s => new { s.TypeId });
            });

            builder.Entity<MLiquidationOption>(b =>
            {
                b.HasKey(s => new { s.OptionId });
                b.HasOne(s => s.MLiquidationItem)
                .WithMany(c => c.MLiquidationOptions)
                .HasForeignKey(s => new { s.TypeId, s.ItemId });
            });

            builder.Entity<ApprLiquidation>(b =>
            {
                b.HasOne(s => s.MLiquidationItem)
                .WithMany(c => c.ApprLiquidations)
                .HasForeignKey(s => new { s.LiquidationType, s.LiquidationItem });

                b.HasOne(s => s.MLiquidationOption)
                .WithMany(c => c.ApprLiquidations)
                .HasForeignKey(s => new { s.LiquidationOption });
            });

            builder.Entity<ApprWorkPaperLandBuildings>().HasIndex(p => new { p.ApprWorkPaperLandBuildingSummaryGuid, p.DataNumber }).IsUnique();
            builder.Entity<ApprWorkPaperMachineMarkets>().HasIndex(p => new { p.ApprWorkPaperMachineMarketSummaryGuid, p.DataNumber }).IsUnique();
            builder.Entity<ApprWorkPaperShopApartments>().HasIndex(p => new { p.ApprWorkPaperShopApartmentSummaryGuid, p.DataNumber }).IsUnique();
            builder.Entity<ApprWorkPaperVehicles>().HasIndex(p => new { p.ApprWorkPaperVehicleSummaryGuid, p.DataNumber }).IsUnique();

            builder.Entity<User>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.UserClaims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.UserLogins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.UserTokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });

            builder.Entity<Role>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();

                b.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(ur => ur.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.ModifiedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.DeletedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.DeletedBy)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<Data.Action>(b =>
            {
                b.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(ur => ur.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.ModifiedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.DeletedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.DeletedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<PageAction>(b =>
            {
                b.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(ur => ur.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.ModifiedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.DeletedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.DeletedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Page>(b =>
            {
                b.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(ur => ur.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.ModifiedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.DeletedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.DeletedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<UserAllowedIP>().HasKey(c => new { c.UserId, c.IPAddress });

            builder.Entity<EmailSMTPSetting>(b =>
            {
                b.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(ur => ur.CreatedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.ModifiedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.ModifiedBy)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.DeletedByUser)
                    .WithMany()
                    .HasForeignKey(rc => rc.DeletedBy)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<RfStage>(b =>
            {
                b.Property(b => b.StageId)
                .HasDefaultValueSql("NEWID()");

                b.Property(b => b.CreatedBy)
                .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

                b.Property(b => b.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

                b.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
            });
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<RoleClaim>().ToTable("RoleClaims");
            builder.Entity<UserClaim>().ToTable("UserClaims");
            builder.Entity<UserLogin>().ToTable("UserLogins");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserToken>().ToTable("UserTokens");
            builder.DefalutMappingValue();
            builder.DefalutDeleteValueFilter();
        }
    }
}
