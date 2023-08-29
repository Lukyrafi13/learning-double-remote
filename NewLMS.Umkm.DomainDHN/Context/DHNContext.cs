using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.DomainDHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.DomainDHN.Context
{
    public class DHNContext : DbContext
    {
        public virtual DbSet<DHNList> DHNLists { get; set; }

        public DHNContext(DbContextOptions<DHNContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DHNList>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }

    
}
