using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.PrescreeningDokumens
{
    public class PrescreeningDokumenResponseDto
    {
        public Guid Id { get; set; }
        
        public Prescreening Prescreening { get; set; }
        public RFDocument Dokumen { get; set; }
        public RFTipeDokumen TipeDokumen { get; set; }
        public RFStatusDokumen DokumenStatus { get; set; }
        public RFColLateralBC JenisAgunan { get; set; }
        public List<FileDokumen> ListFile { get; set; }

        public string DokumenLainnya { get; set; }
        public string NomorDokumen { get; set; }
        public DateTime? TanggalKadaluarsa { get; set; }
        public string DeskripsiTBO { get; set; }
        public DateTime? TanggalTBO { get; set; }
        public DateTime? LastUploadDate { get; set; }
        public string Justifikasi { get; set; }
        public bool? VerifiedByAdmin { get; set; }

        
        public Guid PrescreeningId { get; set; }
        public Guid? RFTipeDokumenId { get; set; }
        public Guid? RFDocumentId { get; set; }
        public Guid? RFStatusDokumenId { get; set; }
        public Guid? RFCollateralBCId { get; set; }
    }
}
