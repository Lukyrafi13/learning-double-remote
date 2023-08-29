using System;

namespace NewLMS.Umkm.Data.Dto.InformasiOmsets
{
    public class InformasiOmsetPostRequestDto
    {
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
