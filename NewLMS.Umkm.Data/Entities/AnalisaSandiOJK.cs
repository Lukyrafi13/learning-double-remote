using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class AnalisaSandiOJK : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("AppFasilitasKreditId")]
        public AppFasilitasKredit AppFasilitasKredit { get; set; }
        [ForeignKey("RFSandiBIGolonganId")]
        public RFSANDIBI GolonganDebitur { get; set; }
        [ForeignKey("RFSandiBIHubunganId")]
        public RFSANDIBI HubunganDenganBank { get; set; }
        [ForeignKey("RFSandiBIStatusDebiturId")]
        public RFSANDIBI StatusDebitur { get; set; }
        [ForeignKey("RFSandiBIKategoriDebiturId")]
        public RFSANDIBI KategoriDebitur { get; set; }
        [ForeignKey("RFSandiBIPortofolioId")]
        public RFSANDIBI KategoriPortofolio { get; set; }
        [ForeignKey("RFSandiBILembagaId")]
        public RFSANDIBI LembagaPemerikatan { get; set; }
        [ForeignKey("RFSandiBIJenisKreditId")]
        public RFSANDIBI JenisKredit { get; set; }
        [ForeignKey("RFSandiBISifatKreditId")]
        public RFSANDIBI SifatKredit { get; set; }
        [ForeignKey("RFSandiBIJenisPenggunaanId")]
        public RFSANDIBI JenisPenggunaan { get; set; }
        [ForeignKey("RFSandiBITakeOverId")]
        public RFSANDIBI TakeOver { get; set; }
        [ForeignKey("RFSandiBIOrientasiId")]
        public RFSANDIBI OrientasiPenggunaan { get; set; }
        [ForeignKey("RFSandiBIKategoriKreditId")]
        public RFSANDIBI KategoriKredit { get; set; }
        [ForeignKey("RFSandiBISukuBungaId")]
        public RFSANDIBI JenisSukuBunga { get; set; }
        [ForeignKey("RFSandiBILokasiProyekId")]
        public RFSANDIBI LokasiProyek { get; set; }
        [ForeignKey("RFSandiBIJenisAgunanId")]
        public RFSANDIBI JenisAgunan { get; set; }
        [ForeignKey("RFSandiBISifatAgunanId")]
        public RFSANDIBI SifatAgunan { get; set; }
        [ForeignKey("RFSandiBIJenisValutaId")]
        public RFSANDIBI JenisValuta { get; set; }
        [ForeignKey("RFSandiBIPenerbitId")]
        public RFSANDIBI PenerbitAgunan { get; set; }
        [ForeignKey("RFSandiBIPeringkatId")]
        public RFSANDIBI PeringkatPenerbitAgunan { get; set; }
        [ForeignKey("RFSandiBIStatusAgunanId")]
        public RFSANDIBI StatusAgunan { get; set; }
        [ForeignKey("RFSandiBISkimId")]
        public RFSANDIBI SkimPembiayaan { get; set; }
        [ForeignKey("RFSandiBIKreditProgramId")]
        public RFSANDIBI KreditProgramPemerintah { get; set; }
        [ForeignKey("RFSandiBISumberDanaId")]
        public RFSANDIBI SumberDana { get; set; }
        
        public Guid AnalisaId { get; set; }
        public Guid? AppFasilitasKreditId { get; set; }
        public Guid? RFSandiBIGolonganId { get; set; }
        public Guid? RFSandiBIHubunganId { get; set; }
        public Guid? RFSandiBIStatusDebiturId { get; set; }
        public Guid? RFSandiBIKategoriDebiturId { get; set; }
        public Guid? RFSandiBIPortofolioId { get; set; }
        public Guid? RFSandiBILembagaId { get; set; }
        public Guid? RFSandiBIJenisKreditId { get; set; }
        public Guid? RFSandiBISifatKreditId { get; set; }
        public Guid? RFSandiBIJenisPenggunaanId { get; set; }
        public Guid? RFSandiBITakeOverId { get; set; }
        public Guid? RFSandiBIOrientasiId { get; set; }
        public Guid? RFSandiBIKategoriKreditId { get; set; }
        public Guid? RFSandiBISukuBungaId { get; set; }
        public Guid? RFSandiBILokasiProyekId { get; set; }
        public Guid? RFSandiBIJenisAgunanId { get; set; }
        public Guid? RFSandiBISifatAgunanId { get; set; }
        public Guid? RFSandiBIJenisValutaId { get; set; }
        public Guid? RFSandiBIPenerbitId { get; set; }
        public Guid? RFSandiBIPeringkatId { get; set; }
        public Guid? RFSandiBIStatusAgunanId { get; set; }
        public Guid? RFSandiBISkimId { get; set; }
        public Guid? RFSandiBIKreditProgramId { get; set; }
        public Guid? RFSandiBISumberDanaId { get; set; }
    }
}