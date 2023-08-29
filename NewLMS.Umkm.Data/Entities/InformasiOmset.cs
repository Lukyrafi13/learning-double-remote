using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class InformasiOmset : BaseEntity
    {
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
        [ForeignKey("RFLuasLahanUsahaId")]
        public RFBentukLahan RFBentukLahan { get; set; }
        [ForeignKey("RFBentukLahanUsaha")]
        public RFSatuanLuas RFSatuanLuas { get; set; }
        public Guid Id { get; set; }
        public int? LuasLahanUsaha { get; set; }
        public int? KapasitasLahanUsaha { get; set; }
        public int? PenjualanTahunanOmset { get; set; }
        public int? KekayaanBersihOmset { get; set; }
        public Guid? SurveyId { get; set; }
        public Guid? RFBentukLahanUsahaId { get; set; }
        public Guid? RFLuasLahanUsahaId { get; set; }
        public Guid? RFBentukLahanUsaha { get; set; }
    }
}
