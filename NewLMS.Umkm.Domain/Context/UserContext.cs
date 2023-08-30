using NewLMS.UMKM.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using NewLMS.UMKM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
// using NewLMS.UMKM.Domain.Services;
using System.Reflection.Emit;

namespace NewLMS.UMKM.Domain.Context
{
    public class UserContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
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
        public virtual DbSet<ThridParty> ThridParties { get; set; }
        public DbSet<RfProduct> RfProducts { get; set; }
        public DbSet<RfOwnerCategory> RfOwnerCategories { get; set; }
        public DbSet<RfGender> RfGenders { get; set; }
        public DbSet<RfTargetStatus> RfTargetStatuses { get; set; }
        public DbSet<RfSectorLBU1> RfSectorLBU1s { get; set; }
        public DbSet<RfSectorLBU2> RfSectorLBU2s { get; set; }
        public DbSet<RfSectorLBU3> RfSectorLBU3s { get; set; }
        public DbSet<RfCompanyGroup> RfCompanyGroups { get; set; }
        public DbSet<RfCompanyType> RfCompanyTypes { get; set; }
        public DbSet<RfCompanyStatus> RfCompanyStatuses { get; set; }
        public DbSet<RfBranch> RfBranches { get; set; }
        public virtual DbSet<RfZipCode> RfZipCodes { get; set; }
        public virtual DbSet<RfAppType> RfAppTypes { get; set; }
        public virtual DbSet<RfCategory> RfCategories { get; set; }
        public virtual DbSet<RfServiceCode> RfServiceCodes { get; set; }
        public DbSet<Prospect> Prospects { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        // public DbSet<LoanApplicationCreditScoring> LoanApplicationCreditScorings { get; set; }
        // public DbSet<LoanApplicationCollateral> LoanApplicationCollaterals { get; set; }
        public DbSet<LoanApplicationStageLogs> LoanApplicationStageLogs { get; set; }
        // public DbSet<LoanApplicationKeyPerson> LoanApplicationKeyPersons { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<DebtorCouple> DebtorCouples { get; set; }
        public DbSet<DebtorCompany> DebtorCompanies { get; set; }
        public DbSet<DebtorEmergency> DebtorEmergencies { get; set; }
        public DbSet<CompanyEntity> CompanyEntities { get; set; }
        // public DbSet<RfStage> RfStages { get; set; }
        public DbSet<RfParameter> RfParameters { get; set; }
        public DbSet<RfParameterDetail> RfParameterDetails { get; set; }
        // public DbSet<Debitur> Debiturs { get; set; }
        public DbSet<RFVEHMAKER> RFVEHMAKER { get; set; }
        public DbSet<RFVEHCLASS> RFVEHCLASS { get; set; }
        public DbSet<RFVEHICLETYPEs> RFVEHICLETYPEs { get; set; }
        // public DbSet<RFSCOREPUTASITEMPATTINGGAL> RFSCOREPUTASITEMPATTINGGAL { get; set; }
        // public DbSet<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN { get; set; }
        // public DbSet<RFSCOCARATRANSAKSI> RFSCOCARATRANSAKSI { get; set; }
        // public DbSet<RFSCOPENGELOLAKEUANGAN> RFSCOPENGELOLAKEUANGAN { get; set; }
        // public DbSet<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN { get; set; }
        // public DbSet<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA { get; set; }
        // public DbSet<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN { get; set; }
        // public DbSet<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN { get; set; }
        // public DbSet<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA { get; set; }
        // public DbSet<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN { get; set; }
        public DbSet<RFEDUCATION> RFEDUCATION { get; set; }
        // public DbSet<RFHOMESTA> RFHOMESTA { get; set; }
        public DbSet<RFJOB> RFJOB { get; set; }
        // public DbSet<RFMARITAL> RFMARITALs { get; set; }
        // public DbSet<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHANs { get; set; }
        // public DbSet<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJBs { get; set; }
        public DbSet<RFColLateralBC> RFColLateralBCs { get; set; }
        // public DbSet<RFLoanPurpose> RFLoanPurpose { get; set; }
        // public DbSet<RFDocument> RFDocuments { get; set; }
        // public DbSet<RFDocumentAgunan> RFDocumentAgunans { get; set; }
        // public DbSet<RFMappingAgunan2> RFMappingAgunan2s { get; set; }
        // public DbSet<RFRelationCol> RFRelationCols { get; set; }
        // public DbSet<RFSubProduct> RFSubProducts { get; set; }
        // public DbSet<RFTenor> RFTenors { get; set; }
        // public DbSet<RFTenorMapping> RFTenorMappings { get; set; }
        // public DbSet<RFSifatKredit> RFSifatKredits { get; set; }
        public DbSet<RFVehModel> RFVehModels { get; set; }
        // public DbSet<RFJenisKendaraanAgunan> RFJenisKendaraanAgunans { get; set; }
        // public DbSet<RFBuktiKepemilikan> RFBuktiKepemilikans { get; set; }
        // public DbSet<RFDecisionSK> RFDecisionSKs { get; set; }
        // public DbSet<RFLokasiTempatUsaha> RFLokasiTempatUsahas { get; set; }
        // public DbSet<RFSubProductTenor> RFSubProductTenors { get; set; }
        public DbSet<RFVehicleTypeList> RFVehicleTypeLists { get; set; }
        // public virtual DbSet<App> Apps { get; set; }
        // public virtual DbSet<AppKeyPerson> AppKeyPersons { get; set; }
        // public virtual DbSet<AppContactPerson> AppContactPersons { get; set; }
        // public DbSet<RFJenisTempatUsaha> RFJenisTempatUsahas { get; set; }
        // public DbSet<RFJumlahPegawai> RFJumlahPegawais { get; set; }
        // public DbSet<RFAspekPemasaran> RFAspekPemasarans { get; set; }
        // public DbSet<RFKepemilikanTU> RFKepemilikanTUs { get; set; }
        // public DbSet<RFCaraPengikatan> RFCaraPengikatans { get; set; }
        // public DbSet<RFRelationSurvey> RFRelationSurveys { get; set; }
        // public DbSet<RFPaymentMethod> RFPaymentMethods { get; set; }
        // public DbSet<RFOwnerOTS> RFOwnerOTSs { get; set; }
        // public DbSet<RfCompanyTypeMap> RfCompanyTypeMaps { get; set; }
        // public DbSet<RFReject> RFRejects { get; set; }
        // public DbSet<RFNegaraPenempatan> RFNegaraPenempatans { get; set; }
        // public DbSet<Prescreening> Prescreenings { get; set; }
        // public DbSet<FileDokumen> FileDokumens { get; set; }
        // public DbSet<PrescreeningDokumen> PrescreeningDokumens { get; set; }
        // public DbSet<RFTipeDokumen> RFTipeDokumens { get; set; }
        // public DbSet<RFStatusDokumen> RFStatusDokumens { get; set; }
        // public DbSet<FileUrl> FileUrls { get; set; }
        // public DbSet<Survey> Surveys { get; set; }
        // public DbSet<SIKPHistory> SIKPHistorys { get; set; }
        // public DbSet<SIKPHistoryDetail> SIKPHistoryDetails { get; set; }
        // public DbSet<SIKPCalonDebitur> SIKPCalonDebiturs { get; set; }
        // public DbSet<SlikRequest> SlikRequests { get; set; }
        // public DbSet<SlikObjectType> SlikObjectTypes { get; set; }
        // public DbSet<SlikRequestObject> SlikRequestObjects { get; set; }
        // public DbSet<RFPilihanPemutus> RFPilihanPemutuss { get; set; }
        // public DbSet<RFBusinessType> RFBusinessTypes { get; set; }
        // public DbSet<RFBidangUsahaKUR> RFBidangUsahaKURs { get; set; }
        // public DbSet<RFMappingLBU3> RFMappingLBU3s { get; set; }
        public DbSet<RfBusinessPrimaryCycle> RfBusinessPrimaryCycles { get; set; }
        // public DbSet<SCJabatan> SCJabatans { get; set; }
        // public DbSet<RFMappingPrescreeningDocument> RFMappingPrescreeningDocuments { get; set; }
        // public DbSet<SurveyBuyer> SurveyBuyers { get; set; }
        // public DbSet<SurveySupplier> SurveySuppliers { get; set; }
        // public DbSet<SurveyFileUpload> SurveyFileUploads { get; set; }
        // public DbSet<Analisa> Analisas { get; set; }
        // public DbSet<RFLokasiUsaha> RFLokasiUsahas { get; set; }
        // public DbSet<RFJenisSyaratKredit> RFJenisSyaratKredits { get; set; }
        // public DbSet<AnalisaSyaratKredit> AnalisaSyaratKredits { get; set; }
        // public DbSet<RFPengikatanKredit> RFPengikatanKredits { get; set; }
        // public DbSet<RFJenisAkta> RFJenisAktas { get; set; }
        // public DbSet<RFLinkage> RFLinkages { get; set; }
        // public DbSet<RFTermCondition> RFTermConditions { get; set; }
        // public DbSet<SPPK> SPPKs { get; set; }
        // public DbSet<Review> Reviews { get; set; }
        // public DbSet<Approval> Approvals { get; set; }
        // public DbSet<AlamatUsahaSamaDenganAplikasi> AlamatUsahaSamaDenganAplikasis { get; set; }
        // public DbSet<DebiturMemilikiUsahaLain> DebiturMemilikiUsahaLains { get; set; }
        // public DbSet<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindaris { get; set; }
        // public DbSet<RFJenisLinkAge> RFJenisLinkAges { get; set; }
        // public DbSet<AnalisaPinjamanDariBank> AnalisaPinjamanDariBanks { get; set; }
        // public DbSet<AnalisaFasilitas> AnalisaFasilitass { get; set; }
        // public DbSet<RFSANDIBI> RFSANDIBIS { get; set; }
        // public DbSet<EnumSandiBIGroup> EnumSandiBIGroups { get; set; }
        // public DbSet<EnumSandiBIType> EnumSandiBITypes { get; set; }
        // public DbSet<AnalisaSandiOJK> AnalisaSandiOJKs { get; set; }
        // public DbSet<RFJenisAsuransi> RFJenisAsuransis { get; set; }
        // public DbSet<RFPolaPengembalian> RFPolaPengembalians { get; set; }
        // public DbSet<RFSubProductInt> RFSubProductInts { get; set; }
        // public DbSet<RFSkemaSIKP> RFSkemaSIKPs { get; set; }
        // public DbSet<RFInsRateTemplate> RFInsRateTemplates { get; set; }
        // public DbSet<RFInsCompany> RFInsCompanys { get; set; }
        // public DbSet<RFBranchInsComp> RFBranchInsComps { get; set; }
        // public DbSet<SlikHistoryKredit> SlikHistoryKredits { get; set; }
        // public DbSet<PersiapanAkad> PersiapanAkads { get; set; }
        // public DbSet<VerifikasiPersiapanAkad> VerifikasiPersiapanAkads { get; set; }
        // public DbSet<ReviewPersiapanAkad> ReviewPersiapanAkads { get; set; }
        // public DbSet<PersiapanAkadAsuransi> PersiapanAkadAsuransis { get; set; }
        // public DbSet<RFTipeKredit> RFTipeKredits { get; set; }
        // public DbSet<RFBank> RFBanks { get; set; }
        // public DbSet<RFCondition> RFConditions { get; set; }
        // public DbSet<RFCSBPDetail> RFCSBPDetails { get; set; }
        // public DbSet<RFCSBPHeader> RFCSBPHeaders { get; set; }
        // public DbSet<Disbursement> Disbursements { get; set; }
        // public DbSet<RFTempalateAkadKredit> RFTempalateAkadKredits { get; set; }
        // public DbSet<RFInsRateMapping> RFInsRateMappings { get; set; }
        // public DbSet<SlikRequestDuplikasi> SlikRequestDuplikasis { get; set; }
        // public DbSet<MSearch> MSearches { get; set; }
        // public DbSet<RFBentukLahan> RFBentukLahans { get; set; }
        // public DbSet<RFSatuanKapasitas> RFSatuanKapasitass { get; set; }
        // public DbSet<RFSatuanLuas> RFSatuanLuass { get; set; }
        // public DbSet<ArusKasMasuk> ArusKasMasuks { get; set; }
        // public DbSet<BiayaInvestasi> BiayaInvestasis { get; set; }
        // public DbSet<BiayaTetap> BiayaTetaps { get; set; }
        // public DbSet<BiayaVariabel> BiayaVariabels { get; set; }
        // public DbSet<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerjas { get; set; }
        // public DbSet<InformasiOmset> InformasiOmsets { get; set; }
        // public DbSet<ApprovalHistory> ApprovalHistorys { get; set; }
        // public DbSet<SPPKFileUpload> SPPKFileUploads { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            builder.Entity<Prospect>(b =>
            {
                b.HasOne(e => e.RfZipCode)
                    .WithMany()
                    .HasForeignKey(ur => ur.ZipCodeId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.RfPlaceZipCode)
                    .WithMany()
                    .HasForeignKey(rc => rc.PlaceZipCodeId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(e => e.RfCompanyZipCode)
                    .WithMany()
                    .HasForeignKey(rc => rc.CompanyZipCodeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // builder.Entity<Debitur>(b =>
            // {
            //     b.HasOne(e => e.JenisKelamin)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.RfGenderId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<RFSubProduct>(b =>
            // {
            //     b.HasOne(e => e.Product)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.ProductId)
            //         .HasPrincipalKey(rc => rc.ProductId)
            //         .IsRequired(false)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<ProspectStageLogs>(b =>
            // {
            //     // b.HasOne(e => e.Prospect)
            //     //     .WithMany()
            //     //     .HasForeignKey(rc => rc.ProspectId)
            //     //     .OnDelete(DeleteBehavior.NoAction);

            //     b.HasOne(e => e.RFStages)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.StageId)
            //         .OnDelete(DeleteBehavior.NoAction);

            //     b.HasOne(e => e.Alasan)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.RFRejectId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<AppKeyPerson>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<AppContactPerson>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<AppFasilitasKredit>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<AppAgunan>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<Prescreening>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<RFMappingPrescreeningDocument>(b =>
            // {
            //     b.HasOne(e => e.RFDocument)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.DocCode)
            //         .HasPrincipalKey(rc => rc.DocCode)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<Analisa>(b =>
            // {
            //     b.HasOne(e => e.App)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.AppId)
            //         .OnDelete(DeleteBehavior.NoAction);
            //     b.HasOne(e => e.Prescreening)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.PrescreeningId)
            //         .OnDelete(DeleteBehavior.NoAction);
            //     b.HasOne(e => e.Survey)
            //         .WithMany()
            //         .HasForeignKey(rc => rc.SurveyId)
            //         .OnDelete(DeleteBehavior.NoAction);
            // });

            // builder.Entity<EnumSandiBIGroup>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<EnumSandiBIType>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFSANDIBI>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFPolaPengembalian>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFSubProductInt>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFSkemaSIKP>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFInsCompany>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFInsRateTemplate>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFBranchInsComp>(b =>
            // {

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<PersiapanAkad>(b =>
            // {

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });
            // builder.Entity<VerifikasiPersiapanAkad>(b =>
            // {

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<ReviewPersiapanAkad>(b =>
            // {

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFCondition>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFBank>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFTipeKredit>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFInsRateMapping>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFCSBPDetail>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //                 .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //                 .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //                 .HasDefaultValue(false);
            // });

            // builder.Entity<MSearch>(b =>
            // {
            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFCSBPHeader>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RFJenisDuplikasi>(b =>
            // {
            //     b.Property(b => b.Id)
            //     .HasDefaultValueSql("NEWID()");

            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

            // builder.Entity<RfZipCode>(b =>
            // {
            //     b.Property(b => b.CreatedBy)
            //     .HasDefaultValue(Guid.Parse("113005DE-06BC-44CB-B97F-A9C65C0C5465"));

            //     b.Property(b => b.CreatedDate)
            //     .HasDefaultValueSql("GETDATE()");

            //     b.Property(b => b.IsDeleted)
            //     .HasDefaultValue(false);
            // });

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
