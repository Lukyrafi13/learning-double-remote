using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NewLMS.Umkm.Data.Dto.PrescreeningDokumens
{
    public class PrescreeningDokumenPostRequestDto
    {
        public string DokumenLainnya { get; set; }
        public string NomorDokumen { get; set; }
        public DateTime? TanggalKadaluarsa { get; set; }
        public DateTime? TanggalTBO { get; set; }
        public string DeskripsiTBO { get; set; }
        public string Justifikasi { get; set; }
        public bool? VerifiedByAdmin { get; set; }        
        public IList<IFormFile> Files { get; set; }
        public IList<string> DocumentSubTypes { get; set; }

        
        public Guid PrescreeningId { get; set; }
        public Guid? RFDocumentId { get; set; }
        public Guid? RFTipeDokumenId { get; set; }
        public Guid? RFStatusDokumenId { get; set; }
        public Guid? RFCollateralBCId { get; set; }
    }
}
