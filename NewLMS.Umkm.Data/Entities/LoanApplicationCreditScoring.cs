using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationCreditScoring : BaseEntity
    {
        public Guid Id { get; set; }

        // Turunan Prospect
        public Guid LoanApplicationGuid { get; set; }

        // Credit Scoring
        public int? SiklusUsahaMonth { get; set; }
        public RFSiklusUsahaPokok SiklusUsahaPokok { get; set; }
        public bool? SiklusUsaha { get; set; }

        // Foreign keys
        public Guid? RFSCOReputasiTempatTinggalId { get; set; }
        public Guid? RFSCOTingkatKebutuhanId { get; set; }
        public Guid? RFSCOCaraTransaksiId { get; set; }
        public Guid? RFSCOPengelolaKeuanganId { get; set; }
        public Guid? RFSCOHutangPihakLainId { get; set; }
        public Guid? RFSCOLokTempatUsahaId { get; set; }
        public Guid? RFSCOHubunganPerbankanId { get; set; }
        public Guid? RFSCOMutasiPerBulanId { get; set; }
        public Guid? RFSCORiwayatKreditBJBId { get; set; }
        public Guid? RFSCOScoringAgunanId { get; set; }
        public Guid? RFSCOSaldoRekRataId { get; set; }
        public Guid? RFSiklusUsahaPokokId { get; set; }
    }
}