using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class ReviewPersiapanAkad : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        [ForeignKey("SppkId")]
        public SPPK SPPK { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("PrescreeningId")]
        public Prescreening Prescreening { get; set; }
        [ForeignKey("PersiapanAkadId")]
        public PersiapanAkad PersiapanAkad { get; set; }

        public Guid LoanApplicationId { get; set; }
        public Guid? SppkId { get; set; }
        public Guid? AnalisaId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? PersiapanAkadId { get; set; }
    }
}
