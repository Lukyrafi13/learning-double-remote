using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class PrescreeningDokumen : BaseEntity
    {
        public Guid Id { get; set; }
        
        [ForeignKey("PrescreeningId")]
        public Prescreening Prescreening { get; set; }

        [ForeignKey("RFDocumentId")]
        public RFDocument Dokumen { get; set; }

        [ForeignKey("RFTipeDokumenId")]
        public RFTipeDokumen TipeDokumen { get; set; }

        [ForeignKey("RFStatusDokumenId")]
        public RFStatusDokumen DokumenStatus { get; set; }

        [ForeignKey("RFCollateralBCId")]
        public RFColLateralBC JenisAgunan { get; set; }

        public string DokumenLainnya { get; set; }
        public string NomorDokumen { get; set; }
        public DateTime? TanggalKadaluarsa { get; set; }
        public DateTime? TanggalTBO { get; set; }
        public string DeskripsiTBO { get; set; }
        public DateTime? LastUploadDate { get; set; }
        public string Justifikasi { get; set; }
        public bool? VerifiedByAdmin { get; set; }

        
        public Guid PrescreeningId { get; set; }
        public Guid? RFDocumentId { get; set; }
        public Guid? RFTipeDokumenId { get; set; }
        public Guid? RFStatusDokumenId { get; set; }
        public Guid? RFCollateralBCId { get; set; }
    }
}
