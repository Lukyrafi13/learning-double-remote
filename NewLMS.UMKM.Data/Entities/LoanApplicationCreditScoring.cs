using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationCreditScoring : BaseEntity
    {
        public Guid Id { get; set; }

        // Turunan Prospect
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        // Credit Scoring
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoResidentialReputationId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoBankRelationId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoBJBCreditHistoryId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoTransacMethodId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoAverageAccBalanceId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoNeedLEvelId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoFinanceManagerId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoBusinesLocationId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoOtherPartysDebtId { get; set; }
        [ForeignKey(nameof(RfParameterDetail))]
        public int ScoCollateralId { get; set; }

        // Foreign keys
        // [ForeignKey(nameof(RFSCOReputasiTempatTinggal))]
        public virtual RfParameterDetail ScoResidentialReputation { get; set; }
        // [ForeignKey(nameof(RFSCOTingkatKebutuhan))]
        public virtual RfParameterDetail ScoBankRelation { get; set; }
        // [ForeignKey(nameof(RFSCOCaraTransaksi))]
        public virtual RfParameterDetail ScoBJBCreditHistory { get; set; }
        // [ForeignKey(nameof(RFSCOPengelolaKeuangan))]
        public virtual RfParameterDetail ScoTransacMethod { get; set; }
        // [ForeignKey(nameof(RFSCOHutangPihakLain))]
        public virtual RfParameterDetail ScoAverageAccBalance { get; set; }
        // [ForeignKey(nameof(RFSCOLokTempatUsaha))]
        public virtual RfParameterDetail ScoNeedLEvel { get; set; }
        // [ForeignKey(nameof(RFSCOHubunganPerbankan))]
        public virtual RfParameterDetail ScoFinanceManager { get; set; }
        // [ForeignKey(nameof(RFSCOMutasiPerBulan))]
        public virtual RfParameterDetail ScoBusinesLocation { get; set; }
        // [ForeignKey(nameof(RFSCORiwayatKreditBJB))]
        public virtual RfParameterDetail ScoOtherPartysDebt { get; set; }
        // [ForeignKey(nameof(RFSCOScoringAgunan))]
        public virtual RfParameterDetail ScoCollateral { get; set; }
        // [ForeignKey(nameof(RFSCOSaldoRekRata))]
    }
}