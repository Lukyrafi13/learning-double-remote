using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLMS.Umkm.Domain.FUSE.Entites;

namespace NewLMS.Umkm.Domain.FUSE.Context
{
    public class FUSEContext : DbContext
    {

        public DbSet<Test> Test { get; set; }
        public DbSet<SBDK> SBDK { get; set; }
        public DbSet<BMPK> BMPK { get; set; }
        // public virtual DbSet<p_pipeline_mkt> p_pipeline_mkt { get; set; }
        // public virtual DbSet<p_pipeline_mkt_detail> p_pipeline_mkt_detail { get; set; }
        // public virtual DbSet<app_wilayah> app_wilayah { get; set; }
        // public virtual DbSet<p_sektor> p_sektor { get; set; }
        // public virtual DbSet<parameters> parameters { get; set; }

        public FUSEContext(DbContextOptions<FUSEContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<SBDK>(sbdk => {
            //     sbdk.HasNoKey();
            // });
            builder.Entity<SBDK>().HasKey(x => new
            {
                x.SBDKGuid
            });
            
            builder.Entity<BMPK>().HasKey(x => new
            {
                x.BMPKId
            });
            // builder.Entity<p_pipeline_mkt_detail>().HasKey(x => new
            // {
            //     x.pipe_pres_id
            // });

            // builder.Entity<app_wilayah>().HasKey(x => new
            // {
            //     x.kode
            // });

            // builder.Entity<p_sektor>().HasKey(x => new
            // {
            //     x.sektor_id
            // });

            // builder.Entity<parameters>().HasKey(x => new
            // {
            //     x.parameter_id
            // });

            // builder.Entity<p_pipeline_mkt>()
            // .HasMany(c => c.p_pipeline_mkt_detail)
            // .WithOne(e => e.p_pipeline_mkt)
            // .HasForeignKey(x => x.pipe_parent_id);

            //builder.Entity<p_sektor>()
            //.HasMany(c => c.p_pipeline_mkt)
            //.WithOne(e => e.Sektor)
            //.HasForeignKey(x => x.pipe_sektor_ekonomi_id);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.Provinsi)
            //.WithOne(x => x.Provinsi)
            //.HasForeignKey(x => x.pipe_provinsi_ktp);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.Kota)
            //.WithOne(x => x.Kota)
            //.HasForeignKey(x => x.pipe_kota_ktp);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.Kelurahan)
            //.WithOne(x => x.Kelurahan)
            //.HasForeignKey(x => x.pipe_kelurahan_ktp);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.Kecamatan)
            //.WithOne(x => x.Kecamatan)
            //.HasForeignKey(x => x.pipe_kecamatan_ktp);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.ProvinsiUsaha)
            //.WithOne(x => x.ProvinsiUsaha)
            //.HasForeignKey(x => x.pipe_provinsi_usaha);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.KotaUsaha)
            //.WithOne(x => x.KotaUsaha)
            //.HasForeignKey(x => x.pipe_kota_usaha);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.KelurahanUsaha)
            //.WithOne(x => x.KelurahanUsaha)
            //.HasForeignKey(x => x.pipe_kelurahan_usaha);

            //builder.Entity<app_wilayah>()
            //.HasMany(x => x.KecamatanUsaha)
            //.WithOne(x => x.KecamatanUsaha)
            //.HasForeignKey(x => x.pipe_kecamatan_usaha);

            //builder.Entity<parameters>()
            //.HasMany(x => x.p_pipeline_mkt_kategori_prospek)
            //.WithOne(x => x.ParameterKategori)
            //.HasForeignKey(x => x.pipe_kategori_prospek);

            //builder.Entity<parameters>()
            //.HasMany(x => x.p_pipeline_mkt_jenis_pipeline)
            //.WithOne(x => x.ParameterJenisPipeline)
            //.HasForeignKey(x => x.pipe_jenis_pipeline);

            //builder.Entity<parameters>()
            //.HasMany(x => x.p_pipeline_mkt_pipeline_progress)
            //.WithOne(x => x.ParameterPipelineProgress)
            //.HasForeignKey(x => x.pipe_pipeline_progress);

            base.OnModelCreating(builder);
        }
    }
}