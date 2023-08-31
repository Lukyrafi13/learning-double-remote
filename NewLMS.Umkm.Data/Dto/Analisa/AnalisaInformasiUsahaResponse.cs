using System;
namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaInformasiUsahaResponse : AnalisaInformasiUsahaPut
    {
        public RFLokasiUsaha LokasiUsaha { get; set; }
        public RFJenisTempatUsaha JenisTempatUsaha { get; set; }
        public RfCompanyGroup KelompokBidangUsaha { get; set; }
        public RfCompanyType JenisUsaha { get; set; }
        public RFLokasiTempatUsaha LokasiTempatUsaha { get; set; }
        public RFKepemilikanTU KepemilikanTU { get; set; }
        public RFBuktiKepemilikan BuktiKepemilikan { get; set; }
        public RFAspekPemasaran AspekPemasaran { get; set; }
        public RFJumlahPegawai JumlahPegawaiTetap { get; set; }
        public RFJumlahPegawai JumlahPegawaiHarian { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public Prescreening Prescreening { get; set; }
        public Survey Survey { get; set; }

        public Guid? PrescreeningId { get; set; }
        public Guid? SurveyId { get; set; }
    }
}
