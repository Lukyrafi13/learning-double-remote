using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationIDEPutRequestDto
    {
        public Guid Id { get; set; }

        public int? BusinessCycleMonth { get; set; }
        public Guid? RfBusinessPrimaryCycleId { get; set; }
        public bool? BusinessCycle { get; set; }

        // Foreign keys
        public int? RFSCOReputasiTempatTinggalId { get; set; }
        public int? RFSCOTingkatKebutuhanId { get; set; }
        public int? RFSCOCaraTransaksiId { get; set; }
        public int? RFSCOPengelolaKeuanganId { get; set; }
        public int? RFSCOHutangPihakLainId { get; set; }
        public int? RFSCOLokTempatUsahaId { get; set; }
        public int? RFSCOHubunganPerbankanId { get; set; }
        public int? RFSCOMutasiPerBulanId { get; set; }
        public int? RFSCORiwayatKreditBJBId { get; set; }
        public int? RFSCOScoringAgunanId { get; set; }
        public int? RFSCOSaldoRekRataId { get; set; }

    }
}
