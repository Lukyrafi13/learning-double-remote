using NewLMS.Umkm.Data;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Data.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace NewLMS.Umkm.Domain
{
    public static class DefaultEntityMappingExtension
    {
        public static void DefalutMappingValue(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Page>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PageAction>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Role>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<AppSetting>()
              .Property(b => b.ModifiedDate)
              .HasDefaultValueSql("getdate()");

        }

        public static void DefalutDeleteValueFilter(this ModelBuilder modelBuilder)
        {

            //  modelBuilder.Entity<User>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<Role>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<Action>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<Page>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<PageAction>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<AppSetting>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<EmailTemplate>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<EmailSMTPSetting>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<Prospect>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<Debtor>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorCollateral>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorCouple>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorEmergency>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorEmergency>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorFinance>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<ReceivedFacility>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<LoanApplication>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<DebtorEmergency>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfBranch>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfCompany>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfProduct>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfProgram>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfSectorLBU1>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfSectorLBU2>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfSectorLBU3>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfSubProduct>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RfSubProgram>()
            //.HasQueryFilter(p => !p.IsDeleted);

            //  modelBuilder.Entity<RFZipCode>()
            //.HasQueryFilter(p => !p.IsDeleted);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                string[] excludes =
                {
                    "UserToken",
                    "UserRole",
                    "UserLogin",
                    "UserClaim",
                    "UserAllowedIP",
                    "RoleClaim",
                    "NLog",
                    "LoginAudit",
                    "SpGetScoring",
                    "SpGetInterest",
                    "SpGetSchemaFasilitas",
                    "__EFMigrationsHistory",
                    "DecisionResultNew",
                    "DecisionResultDetailNew",
                    "SpGetInterestSimulation",
                    "SpGetSchemaFasilitasSimulation",
                    "mDecision",
                    "mDecisionSegment",
                    "mDecisionParameter",
                    "mDecisionResult",
                    "mDecisionItem",
                    "mDecisionCategory",
                    "mDecisionCard",
                    "mDecisionSegmentCondition",
                    "mDecisionCardSegment",
                    "mDecisionCardCondition"
                };

                if(!excludes.Contains(entityType.ClrType.Name))
                {
                    modelBuilder.Entity(entityType.ClrType).Property<bool>("IsDeleted");
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, Expression.Constant("IsDeleted")),
                    Expression.Constant(false));
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
                }
            }
        }
    }
}
