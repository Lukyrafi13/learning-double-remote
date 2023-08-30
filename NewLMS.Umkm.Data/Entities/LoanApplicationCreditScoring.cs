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
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationGuid { get; set; }

        // Credit Scoring
        public int? BusinessCycleMonth { get; set; }
        [ForeignKey(nameof(RfBusinessPrimaryCycle))]
        public Guid? RfBusinessPrimaryCycleId { get; set; }
        public bool? BusinessCycle { get; set; }

        // Foreign keys
        [ForeignKey(nameof(RFSCOReputasiTempatTinggal))]
        public int? RFSCOReputasiTempatTinggalId { get; set; }
        [ForeignKey(nameof(RFSCOTingkatKebutuhan))]
        public int? RFSCOTingkatKebutuhanId { get; set; }
        [ForeignKey(nameof(RFSCOCaraTransaksi))]
        public int? RFSCOCaraTransaksiId { get; set; }
        [ForeignKey(nameof(RFSCOPengelolaKeuangan))]
        public int? RFSCOPengelolaKeuanganId { get; set; }
        [ForeignKey(nameof(RFSCOHutangPihakLain))]
        public int? RFSCOHutangPihakLainId { get; set; }
        [ForeignKey(nameof(RFSCOLokTempatUsaha))]
        public int? RFSCOLokTempatUsahaId { get; set; }
        [ForeignKey(nameof(RFSCOHubunganPerbankan))]
        public int? RFSCOHubunganPerbankanId { get; set; }
        [ForeignKey(nameof(RFSCOMutasiPerBulan))]
        public int? RFSCOMutasiPerBulanId { get; set; }
        [ForeignKey(nameof(RFSCORiwayatKreditBJB))]
        public int? RFSCORiwayatKreditBJBId { get; set; }
        [ForeignKey(nameof(RFSCOScoringAgunan))]
        public int? RFSCOScoringAgunanId { get; set; }
        [ForeignKey(nameof(RFSCOSaldoRekRata))]
        public int? RFSCOSaldoRekRataId { get; set; }

        public RfBusinessPrimaryCycle RfBusinessPrimaryCycle { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public RfParameterDetail RFSCOReputasiTempatTinggal { get; set; }
        public RfParameterDetail RFSCOTingkatKebutuhan { get; set; }
        public RfParameterDetail RFSCOCaraTransaksi { get; set; }
        public RfParameterDetail RFSCOPengelolaKeuangan { get; set; }
        public RfParameterDetail RFSCOHutangPihakLain { get; set; }
        public RfParameterDetail RFSCOLokTempatUsaha { get; set; }
        public RfParameterDetail RFSCOHubunganPerbankan { get; set; }
        public RfParameterDetail RFSCOMutasiPerBulan { get; set; }
        public RfParameterDetail RFSCORiwayatKreditBJB { get; set; }
        public RfParameterDetail RFSCOScoringAgunan { get; set; }
        public RfParameterDetail RFSCOSaldoRekRata { get; set; }
        
    }
}