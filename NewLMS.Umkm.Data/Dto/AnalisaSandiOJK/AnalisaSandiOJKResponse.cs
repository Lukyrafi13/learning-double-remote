using System;
namespace NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs
{
    public class AnalisaSandiOJKResponseDto
    {
        public Guid Id { get; set; }
        public Analisa Analisa { get; set; }
        public AppFasilitasKredit AppFasilitasKredit { get; set; }
        public RFSANDIBI GolonganDebitur { get; set; }
        public RFSANDIBI HubunganDenganBank { get; set; }
        public RFSANDIBI StatusDebitur { get; set; }
        public RFSANDIBI KategoriDebitur { get; set; }
        public RFSANDIBI KategoriPortofolio { get; set; }
        public RFSANDIBI LembagaPemerikatan { get; set; }
        public RFSANDIBI JenisKredit { get; set; }
        public RFSANDIBI SifatKredit { get; set; }
        public RFSANDIBI JenisPenggunaan { get; set; }
        public RFSANDIBI TakeOver { get; set; }
        public RFSANDIBI OrientasiPenggunaan { get; set; }
        public RFSANDIBI KategoriKredit { get; set; }
        public RFSANDIBI JenisSukuBunga { get; set; }
        public RFSANDIBI LokasiProyek { get; set; }
        public RFSANDIBI JenisAgunan { get; set; }
        public RFSANDIBI SifatAgunan { get; set; }
        public RFSANDIBI JenisValuta { get; set; }
        public RFSANDIBI PenerbitAgunan { get; set; }
        public RFSANDIBI PeringkatPenerbitAgunan { get; set; }
        public RFSANDIBI StatusAgunan { get; set; }
        public RFSANDIBI SkimPembiayaan { get; set; }
        public RFSANDIBI KreditProgramPemerintah { get; set; }
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
