using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppIDEPutRequestDtoResponse : AppIDEPutRequestDto
    {
        public Guid ProspectId { get; set; }
        public RFProduct JenisProduk { get; set; }
        public RFOwnerCategory TipeDebitur { get; set; }
        public RFSCOREPUTASITEMPATTINGGAL ReputasiTempatTinggal { get; set; }
        public RFSCOTINGKATKEBUTUHAN TingkatKebutuhan { get; set; }
        public RFSCOCARATRANSAKSI CaraTransaksi { get; set; }
        public RFSCOPENGELOLAKEUANGAN PengelolaKeuangan { get; set; }
        public RFSCOHUTANGPIHAKLAIN HutangPihakLain { get; set; }
        public RFSCOLOKTEMPATUSAHA LokTempatUsaha { get; set; }
        public RFSCOHUBUNGANPERBANKAN HubunganPerbankan { get; set; }
        public RFSCOMUTASIPERBULAN MutasiPerBulan { get; set; }
        public RFSCORiwayatKreditBJB RiwayatKreditBJB { get; set; }
        public RFSCOSCORINGAGUNAN ScoringAgunan { get; set; }
        public RFSCOSALDOREKRATA SaldoRekRata { get; set; }
        public RfBranches BookingOffice { get; set; }
        public RFSiklusUsahaPokok SiklusUsahaPokok { get; set; }
        // public RFSiklusUsaha SiklusUsahaMonth { get; set; }
    }
}
