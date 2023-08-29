using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.Domain.Dwh.Entities;
using System;

namespace NewLMS.UMKM.Domain.Dwh.Context
{
    public class DWHContext : DbContext
    {
        public virtual DbSet<DownloadData> DownloadDatas { get; set; }
        public virtual DbSet<STG_CIF> STG_CIF { get; set; }
        public virtual DbSet<STG_LOAN> STG_LOAN { get; set; }
        public virtual DbSet<DWH_EXTERNALACC> DWH_EXTERNALACC { get; set; }
        public virtual DbSet<COLLATERAL> COLLATERAL { get; set; }
        public virtual DbSet<PH_GABUNGAN> PH_GABUNGAN { get; set; }
        public DWHContext(DbContextOptions<DWHContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<STG_CIF>().HasKey(x => new
            {
                x.CIF
            });
            builder.Entity<STG_LOAN>().HasKey(x => new
            {
                x.DEAL_REF,
                x.BRANCH,
                x.DEAL_TYPE
            });
            builder.Entity<COLLATERAL>().HasKey(x => new
            {
                x.DEAL_REF,
                x.DEAL_TYPE
            });
            builder.Entity<PH_GABUNGAN>().HasKey(x => new
            {
                x.CIF,
                x.DEAL_REF
            });
            base.OnModelCreating(builder);
        }
    }
}