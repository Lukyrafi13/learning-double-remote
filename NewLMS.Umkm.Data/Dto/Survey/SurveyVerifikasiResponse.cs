using System;

namespace NewLMS.UMKM.Data.Dto.Surveys
{
    public class SurveyVerifikasiResponse : SurveyVerifikasiPut
    {
        public Guid AppId { get; set; }
        public double? GPMTerendah { get; set; }
        public double? BiayaRumahTanggaKeseluruhan { get; set; }
        public double? TotalBiayaUsaha { get; set; }
        public double? HPPPersen { get; set; }
        public double? HPPNilai { get; set; }
        public double? BiayaRumahTanggaTertinggi { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public RFKepemilikanUsaha KepemilikanTempatUsaha { get; set; }
        public RFLamaUsahaLain LamaMenempatiLokasi { get; set; }
    }
}
