using System;

namespace NewLMS.Umkm.Data.Dto.Surveys
{
    public class SurveyOTSPut
    {
        public Guid Id { get; set; }
        public DateTime? TanggalSurvey { get; set; }
        public string NamaSurveyor { get; set; }
        public string NamaVerifikator { get; set; }
        public string OrangDitemui { get; set; }
        public string NamaPerusahaan { get; set; }
        public string NoTelpPerusahaan { get; set; }
        public int? LamaTahunBerdiri { get; set; }
        public int? LamaBulanBerdiri { get; set; }
        public int? JumlahKaryawan { get; set; }
        public int? JumlahCabang { get; set; }
        public bool? AlamatSamaDenganDebitur { get; set; }
        public string AlamatSurveyor { get; set; }
        public string ProvinsiSurveyor { get; set; }
        public string KabupatenKotaSurveyor { get; set; }
        public string KecamatanSurveyor { get; set; }
        public string KelurahanSurveyor { get; set; }
        public string KesimpulanHasil { get; set; }

        public Guid? RFRelationSurveyId { get; set; }
        public Guid? RFOwnerCategoryId { get; set; }
        public Guid? RFOwnerOTSId { get; set; }
        public Guid? RFBidangUsahaKURId { get; set; }
        public int? RFZipCodeId { get; set; }
    }
}
