using NewLMS.UMKM.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using NewLMS.UMKM.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual DbSet<RfZipCode> RfZipCodes { get; set; }
        public DbSet<Prospect> Prospects { get; set; }

        #region References
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
        #endregion


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
